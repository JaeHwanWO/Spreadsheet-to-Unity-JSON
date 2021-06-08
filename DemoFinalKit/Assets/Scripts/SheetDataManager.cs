using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetDataManager : MonoBehaviour {
    public static SheetDataManager Instance { get; private set; } = null;

    private void Awake() {
        Instance = this;
    }

    [SerializeField] TowerSheet _towerDataInstance = default;
    [SerializeField] BulletSheet _bulletDataInstance = default;

    public TowerSheetData[] towerDataList { get { return _towerDataInstance.dataArray; } }
    public BulletSheetData[] bulletDataList { get { return _bulletDataInstance.dataArray; } }
}
