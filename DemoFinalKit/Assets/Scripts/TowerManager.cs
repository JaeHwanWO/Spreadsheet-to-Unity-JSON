using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {
    private static TowerManager _instance = null;
    public static TowerManager Instance { get { return _instance; } }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    [SerializeField] List<TowerData> _towerDatas;
    public List<TowerData> towerDatas { get { return _towerDatas; } }
}
