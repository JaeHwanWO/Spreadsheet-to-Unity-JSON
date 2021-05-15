using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTower : MonoBehaviour
{
    [Header("- UI")]
    [SerializeField]
    protected SpriteRenderer buildUI;
    [Header("- Area")]
    [SerializeField]
    protected Collider2D buildArea;
    [SerializeField]
    protected Collider2D attackArea;
    [Header("- Cost")]
    public int cost;
    [Header("- Sprite")]
    [SerializeField] SpriteRenderer _spriteBase;
    [SerializeField] SpriteRenderer _spriteBarrel;
    [Header("- Attribute")]
    [SerializeField] Transform _barrel;
    [SerializeField] Transform _bulltetPos;

    private float _atkDelay;
    private int _atkCount;

    private int _atkDamage;

    private BulletType _bulletType;

    private IEnumerator uiRoutine;

    public void SetData(TowerData data) {
        cost = data.cost;

        _spriteBase.sprite = ResourceLoader.Instance.LoadSprite_TowerBase(data.sprite_Base);
        _spriteBarrel.sprite = ResourceLoader.Instance.LoadSprite_TowerBarrel(data.sprite_Barrel);

        ((CircleCollider2D)attackArea).radius = data.atkRange;
        _atkDelay = data.atkDelay;
        _atkCount = data.atkCount;

        _bulltetPos.position = transform.position + new Vector3(data.bulletPos, 0f, 0f);

        _bulletType = data.bulletType;
        _atkDamage = data.bulletDamage;
    }

    public void Attack() {
        StartCoroutine(_Attack());
    }

    private float _curDelay = 0f;
    private IEnumerator _Attack() {
        _curDelay = _atkDelay;

        List<Collider2D> collider2Ds = new List<Collider2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Monster"));
        Physics2D.OverlapCollider(attackArea, contactFilter2D, collider2Ds);

        int shootCount = 0;
        for (int i = 0; i < collider2Ds.Count; ++i) {
            if (collider2Ds[i] == null) continue;
            if (shootCount >= _atkCount) break;
            shootCount += 1;
            Monster target = collider2Ds[i].GetComponent<Monster>();
            StartCoroutine(Shoot(i == 0 ? _lastTarget : target));
            yield return new WaitForSeconds(0.1f);
        }

        IEnumerator Shoot(Monster _target) {
            GameObject newBullet = ResourceLoader.Instance.Load_Bullet(_bulletType);
            Vector3 firstPos = transform.position;
            newBullet.transform.position = firstPos;
            newBullet.SetActive(true);

            float deltaTime = 0f;
            while (deltaTime < 0.5f) {
                yield return null;
                deltaTime += Time.deltaTime;
                if (_target == null) break;
                newBullet.transform.position = Vector3.Lerp(firstPos, _target.transform.position, deltaTime / 0.5f);
                LookAt(newBullet.transform, _target);
            }

            if (_target != null) {
                newBullet.transform.position = _target.transform.position;
                switch (_bulletType) {
                    case BulletType.Normal: _target.GetDamage(_atkDamage); break;
                    case BulletType.Dot: _target.GetDamageByTime(_atkDamage, 2f); break;
                }
            }
            Destroy(newBullet);
        }
    }

    public void Init() {
        StartCoroutine(Routine());
    }


    private Monster _lastTarget;
    private IEnumerator Routine() {
        while (true) {
            if (_curDelay > 0) _curDelay -= Time.deltaTime;
            if (_curDelay < 0) _curDelay = 0;

            List<Collider2D> collider2Ds = new List<Collider2D>();
            ContactFilter2D contactFilter2D = new ContactFilter2D();
            contactFilter2D.SetLayerMask(LayerMask.GetMask("Monster"));
            if (Physics2D.OverlapCollider(attackArea, contactFilter2D, collider2Ds) > 0) {
                if (_curDelay <= 0) {
                    Attack();
                }
                if (_lastTarget == null) { _lastTarget = collider2Ds[0].GetComponent<Monster>(); }
                bool isTarget = false;
                // 타겟이 범위 안에 계속 존재하면 유지한다.
                for (int i = 0; i < collider2Ds.Count; ++i) {
                    Monster tempMonster = collider2Ds[i].GetComponent<Monster>();
                    if (tempMonster == null) continue;
                    if (tempMonster == _lastTarget) {
                        isTarget = true;
                        break;
                    }
                }
                if (isTarget == false) {
                    _lastTarget = collider2Ds[0].GetComponent<Monster>();
                }
                LookAt(_barrel, _lastTarget);
            } else {
                _lastTarget = null;
                _barrel.Rotate(new Vector3(0, 0, -2f));
            }
            yield return null;
        }
    }

    private void LookAt(Transform tr, Monster _target) {
        Vector3 targetPos = _target.transform.position;
        Vector3 dir = targetPos - tr.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Remove() {
        StopAllCoroutines();
        Destroy(gameObject);
    }
    
    public void ShowBuildUI() {
        buildUI.enabled = true;
        if(uiRoutine == null) {
            uiRoutine = UIRoutine();
            StartCoroutine(uiRoutine);
        }
    }

    public void HideBuildUI() {
        buildUI.enabled = false;
        if(uiRoutine != null) {
            StopCoroutine(uiRoutine);
            uiRoutine = null;
        }
    }

    private IEnumerator UIRoutine() {
        while (buildUI.enabled) {
            yield return null;
            buildUI.color = CheckArea() ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
        }
    }

    public bool CheckArea() {
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Terrain", "BuildArea"));
        return Physics2D.OverlapCollider(buildArea, contactFilter2D, new List<Collider2D>()) <= 0;
    }
}
