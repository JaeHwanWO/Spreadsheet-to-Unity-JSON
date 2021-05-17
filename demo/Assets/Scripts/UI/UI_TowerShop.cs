using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_TowerShop : MonoBehaviour {
    [SerializeField] List<SubUI_Tower> _towers;

    private void Start() {
        int i = 0;
        List<TowerData> towerDatas = TowerManager.Instance.towerDatas;
        foreach (TowerData data in towerDatas) {
            _towers[i].gameObject.SetActive(true);
            _towers[i].Init(data, OnTowerButtonClicked);
            i++;
        }
    }

    private void OnTowerButtonClicked(TowerData data) {
        MyBuilder.Instance.Build(data);
    }
}
