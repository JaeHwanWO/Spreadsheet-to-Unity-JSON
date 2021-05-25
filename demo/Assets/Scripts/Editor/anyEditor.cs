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
[CustomEditor(typeof(any))]
public class anyEditor : BaseGoogleEditor<any>
{	    
    public override bool Load()
    {        
        any targetData = target as any;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<anyData>(targetData.WorksheetName) ?? db.CreateTable<anyData>(targetData.WorksheetName);
        
        List<anyData> myDataList = new List<anyData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            anyData data = new anyData();
            
            data = Cloner.DeepCopy<anyData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
