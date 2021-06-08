using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_TowerShop : MonoBehaviour {
    [SerializeField] List<SubUI_Tower> _towers;

    private void Start() {
        int i = 0;
        var towerDatas = SheetDataManager.Instance.towerDataList;
        foreach (TowerSheetData data in towerDatas) {
            _towers[i].gameObject.SetActive(true);
            _towers[i].Init(data, OnTowerButtonClicked);
            i++;
        }
    }

    private void OnTowerButtonClicked(TowerSheetData data) {
        MyBuilder.Instance.Build(data);
    }
}
