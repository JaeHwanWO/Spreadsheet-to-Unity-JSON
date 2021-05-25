using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/BulletSheet")]
    public static void CreateBulletSheetAssetFile()
    {
        BulletSheet asset = CustomAssetUtility.CreateAsset<BulletSheet>();
        asset.SheetName = "TowerDB";
        asset.WorksheetName = "BulletSheet";
        EditorUtility.SetDirty(asset);        
    }
    
}