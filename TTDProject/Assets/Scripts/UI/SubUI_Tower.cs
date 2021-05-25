using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnTowerButtonClicked(TowerSheetData data);

public class SubUI_Tower : MonoBehaviour {
    [SerializeField] Image _imgTowerBase;
    [SerializeField] Image _imgTowerBarrel;
    [SerializeField] Text _txtCost;
    [SerializeField] Button _button;

    private TowerSheetData _refData;

    public void Init(TowerSheetData data, OnTowerButtonClicked onClicked) {
        _refData = data;

        _button.onClick.AddListener(() => { onClicked?.Invoke(_refData); });

        _imgTowerBase.sprite = ResourceLoader.Instance.LoadSprite_TowerBase(data.Spritebase);
        _imgTowerBarrel.sprite = ResourceLoader.Instance.LoadSprite_TowerBarrel(data.Spritebarrel);
        _txtCost.text = data.Cost.ToString();
    }
}
