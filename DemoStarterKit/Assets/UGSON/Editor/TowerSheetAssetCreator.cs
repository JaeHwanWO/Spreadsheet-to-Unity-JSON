using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/TowerSheet")]
    public static void CreateTowerSheetAssetFile()
    {
        TowerSheet asset = CustomAssetUtility.CreateAsset<TowerSheet>();
        asset.SheetName = "TowerDB";
        asset.WorksheetName = "TowerSheet";
        EditorUtility.SetDirty(asset);        
    }
    
}