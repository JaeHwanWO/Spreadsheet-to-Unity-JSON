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
[CustomEditor(typeof(BulletSheet))]
public class BulletSheetEditor : BaseGoogleEditor<BulletSheet>
{	    
    public override bool Load()
    {        
        BulletSheet targetData = target as BulletSheet;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<BulletSheetData>(targetData.WorksheetName) ?? db.CreateTable<BulletSheetData>(targetData.WorksheetName);
        
        List<BulletSheetData> myDataList = new List<BulletSheetData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            BulletSheetData data = new BulletSheetData();
            
            data = Cloner.DeepCopy<BulletSheetData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
