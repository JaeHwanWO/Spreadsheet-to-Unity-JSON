using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/any")]
    public static void CreateanyAssetFile()
    {
        any asset = CustomAssetUtility.CreateAsset<any>();
        asset.SheetName = "MySpreadSheet";
        asset.WorksheetName = "any";
        EditorUtility.SetDirty(asset);        
    }
    
}