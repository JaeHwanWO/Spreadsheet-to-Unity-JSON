using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyBuilder : MonoBehaviour
{
    private static MyBuilder _instance = null;
    public static MyBuilder Instance { get { return _instance; } }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Transform _towerParent;

    private static IEnumerator buildRoutine;

    public void Build(MyTower tower)
    {
        if (buildRoutine == null)
        {
            if (TimeManager.Instance.time >= tower.cost)
            {
                buildRoutine = BuildRoutine(tower);
                StartCoroutine(buildRoutine);
            }
        }
    }

    public void Remove()
    {
        if(buildRoutine == null)
        {
            buildRoutine = RemoveRoutine();
            StartCoroutine(buildRoutine);
        }
    }

    public void Build(TowerSheetData data) {
        if (buildRoutine == null) {
            if (TimeManager.Instance.time >= data.Cost) {
                buildRoutine = BuildRoutine(data);
                StartCoroutine(buildRoutine);
            }
        }
    }

    private IEnumerator RemoveRoutine()
    {
        bool isEnd = false;
        while (isEnd == false)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false);
            Collider2D[] colliderArray = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), LayerMask.GetMask("BuildArea"));
            if(colliderArray.Length > 0)
            {
                MyTower target = colliderArray[0].GetComponent<MyTower>();
                target?.Remove();
                isEnd = true;
            }
        }
        buildRoutine = null;
    }

    private IEnumerator BuildRoutine(TowerSheetData data) {
        WaitUntil uiCheck = new WaitUntil(() => EventSystem.current.IsPointerOverGameObject() == false);
        yield return uiCheck;
        MyTower newTower = ResourceLoader.Instance.Load_Tower(data);
        newTower.transform.parent = _towerParent;
        bool isBuild = false;
        newTower.ShowBuildUI();
        while (isBuild == false) {
            yield return uiCheck;
            newTower.transform.localPosition = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (newTower.CheckArea()) {
                if (Input.GetMouseButton(0)) {
                    isBuild = true;
                    break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                break;
            }
            if (TimeManager.Instance.time < newTower.cost) {
                break;
            }
            yield return null;
        }

        if (isBuild) {
            newTower.HideBuildUI();
            newTower.Init();
            TimeManager.Instance.time -= newTower.cost;
        } else {
            Destroy(newTower.gameObject);
        }
        buildRoutine = null;
    }

    private IEnumerator BuildRoutine(MyTower tower)
    {
        WaitUntil uiCheck = new WaitUntil(() => EventSystem.current.IsPointerOverGameObject() == false);
        yield return uiCheck;
        MyTower newTower = Instantiate(tower, _towerParent);
        bool isBuild = false;
        newTower.ShowBuildUI();
        while(isBuild == false)
        {
            yield return uiCheck;
            newTower.transform.localPosition = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (newTower.CheckArea())
            {
                if (Input.GetMouseButton(0))
                {
                    isBuild = true;
                    break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                break;
            }
            if(TimeManager.Instance.time < newTower.cost)
            {
                break;
            }
            yield return null;
        }

        if (isBuild)
        {
            newTower.HideBuildUI();
            newTower.Init();
            TimeManager.Instance.time -= newTower.cost;
        }
        else
        {
            Destroy(newTower.gameObject);
        }
        buildRoutine = null;
    }

}
