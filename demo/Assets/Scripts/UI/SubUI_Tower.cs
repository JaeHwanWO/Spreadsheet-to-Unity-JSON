using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnTowerButtonClicked(TowerData data);

public class SubUI_Tower : MonoBehaviour {
    [SerializeField] Image _imgTowerBase;
    [SerializeField] Image _imgTowerBarrel;
    [SerializeField] Text _txtCost;
    [SerializeField] Button _button;

    private TowerData _refData;

    public void Init(TowerData data, OnTowerButtonClicked onClicked) {
        _refData = data;

        _button.onClick.AddListener(() => { onClicked?.Invoke(_refData); });

        _imgTowerBase.sprite = ResourceLoader.Instance.LoadSprite_TowerBase(data.sprite_Base);
        _imgTowerBarrel.sprite = ResourceLoader.Instance.LoadSprite_TowerBarrel(data.sprite_Barrel);
        _txtCost.text = data.cost.ToString();
    }
}
