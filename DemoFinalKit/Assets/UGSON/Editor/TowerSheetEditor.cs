using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(TowerSheet))]
public class TowerSheetEditor : BaseGoogleEditor<TowerSheet>
{	    
    public override bool Load()
    {        
        TowerSheet targetData = target as TowerSheet;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<TowerSheetData>(targetData.WorksheetName) ?? db.CreateTable<TowerSheetData>(targetData.WorksheetName);
        
        List<TowerSheetData> myDataList = new List<TowerSheetData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            TowerSheetData data = new TowerSheetData();
            
            data = Cloner.DeepCopy<TowerSheetData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
