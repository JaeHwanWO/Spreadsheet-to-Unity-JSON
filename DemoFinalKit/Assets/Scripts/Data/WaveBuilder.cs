using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class TurnInfo {
    public TurnInfo(int spawnerID, int monsterID, int delay) {
        _spawnerID = spawnerID;
        _monsterID = monsterID;
        _delay = delay;
    }

    [SerializeField] int _spawnerID;
    public int spawnerID { get { return _spawnerID; } }

    [SerializeField] int _monsterID;
    public int monsterID { get { return _monsterID; } }

    [SerializeField] int _delay;
    public int delay { get { return _delay; } }
}

public class WaveData : ScriptableObject {
    [SerializeField] List<TurnInfo> _turnInfos;

    [SerializeField] int _maxTurn;
    public int maxTurn { get { return _maxTurn; } set { _maxTurn = value; } }

    public void AddEntity(int spawnerID, int monsterID, int delay) {
        if (_turnInfos == null) {
            _turnInfos = new List<TurnInfo>();
        }
        _turnInfos.Add(new TurnInfo(spawnerID, monsterID, delay));
    }

    public TurnInfo GetTurnInfo(int turn) {
        return _turnInfos[turn];
    }
}

public class WaveDatabase : ScriptableObject {
    [SerializeField] List<WaveData> _waveDatas;

    [SerializeField] int _maxWave;
    public int maxWave { get { return _maxWave; } set { _maxWave = value; } }

    public void AddData(WaveData data) {
        if (_waveDatas == null) {
            _waveDatas = new List<WaveData>();
        }
        _waveDatas.Add(data);
    }

    public WaveData GetData(int wave) {
        return _waveDatas[wave];
    }
}

public class WaveBuilder {

    [MenuItem("Database/Build Wave")]
    public static void BuildDB() {

        WaveDatabase waveDatabase = ScriptableObject.CreateInstance<WaveDatabase>();
        using (StreamReader reader = new StreamReader("Assets/Resources/Database/CSVFiles/waveManagement.csv")) {
            string nextSign = "#Next";
            string endSign = "#End";

            int wave = 0;
            int turn = 0;

            bool isEnd = false;

            while (true) {
                WaveData waveData = ScriptableObject.CreateInstance<WaveData>();

                turn = 0;

                while (true) {
                    string readLine = reader.ReadLine();
                    int offset = (wave) * 3;

                    string[] splitedLine = readLine.Split(',');

                    if (splitedLine[offset].Equals(endSign)) {
                        isEnd = true;
                        break;
                    } else if (splitedLine[offset].Equals(nextSign)) {
                        break;
                    }

                    waveData.AddEntity(int.Parse(splitedLine[offset]), int.Parse(splitedLine[offset + 1]), int.Parse(splitedLine[offset + 2]));

                    turn++;
                }
                waveData.maxTurn = turn;

                waveDatabase.AddData(waveData);

                AssetDatabase.CreateAsset(waveData, $"Assets/Resources/Database/Wave/WaveData_{wave}.asset");
                EditorUtility.SetDirty(waveData);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                if (isEnd) break;

                wave++;

                reader.BaseStream.Position = 0;
            }

            waveDatabase.maxWave = wave;
        }

       
        AssetDatabase.CreateAsset(waveDatabase, "Assets/Resources/Database/Wave/WaveDatabase.asset");
        EditorUtility.SetDirty(waveDatabase);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
