using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public enum BulletType {
    Normal = 0, Dot = 1,
}

public class TowerData : ScriptableObject {
    [SerializeField] int _sprite_Base;
    public int sprite_Base { get { return _sprite_Base; } }
    [SerializeField] int _sprite_Barrel;
    public int sprite_Barrel { get { return _sprite_Barrel; } }

    [SerializeField] int _cost;
    public int cost { get { return _cost; } }

    [SerializeField] float _atkRange;
    public float atkRange { get { return _atkRange; } }

    [SerializeField] float _atkDelay;
    public float atkDelay { get { return _atkDelay; } }
    [SerializeField] int _atkCount;
    public int atkCount { get { return _atkCount; } }

    [SerializeField] float _bulletPos;
    public float bulletPos { get { return _bulletPos; } }

    [SerializeField] BulletType _bulletType;
    public BulletType bulletType { get { return _bulletType; } }
    [SerializeField] int _bulletDamage;
    public int bulletDamage { get { return _bulletDamage; } }
}

public class TowerDataGenerator {
    private const string _defaultFileName = "NewTowerData";
    private const string _extension = ".asset";

    [MenuItem("Assets/Create/Sheet2Unity/Demo/TowerData")]
    public static void GenerateEditor() {
        ScriptableObject scriptableObject = ScriptableObject.CreateInstance<TowerData>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "") {
            path = "Assets";
        } else if (Path.GetExtension(path) != "") {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        AssetDatabase.CreateAsset(scriptableObject, path + "/" + _defaultFileName + _extension);
        AssetDatabase.SaveAssets();

        Selection.activeObject = scriptableObject;
    }
}
