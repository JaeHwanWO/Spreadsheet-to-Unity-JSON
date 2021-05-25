using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;

        Init();
    }

    public GameObject monsterPrefab;
    public WaveDatabase waveDB;
    public MonsterDatabase monsterDB;
    public MySpawner[] spawner;

    public Text text;

    public Monster InstantiateMonster()
    {
        Monster monster = Instantiate(monsterPrefab).GetComponent<Monster>();
        return monster;
    }

    private void Init()
    {
        StartCoroutine(GameRoutine()); //임시
    }

    int maxWave;        
    IEnumerator GameRoutine()
    {
        yield return new WaitForSeconds(1f);

        int wave = 0;
        int turn = 0;

        int spawnerId = 0;
        int monsterId = 0;
        int spawnDelay = 0;

        while(true)
        {
            Debug.Log($"Now Wave : {wave}");

            if (wave > maxWave)
            {
                wave = 0;
            }

            turn = 0;

            WaveData waveData = waveDB.GetData(wave);

            while(true)
            {
                if (turn >= waveData.maxTurn)
                {
                    break;
                }
                Debug.Log($"turn : {turn} / maxTurn : {waveData.maxTurn}");

                TurnInfo turnInfo = waveData.GetTurnInfo(turn);

                spawnerId = turnInfo.spawnerID;
                monsterId = turnInfo.monsterID;
                spawnDelay = turnInfo.delay;

                spawner[spawnerId].Spawn(monsterDB.GetData(monsterId));

                yield return new WaitForSeconds(spawnDelay);

                turn++;
            }

            wave++;
            TimeManager.Instance.time += 100;

            yield return null;
            //yield return WaitUntil 준비 기간 동안 정지
        }
    }

    public void GameOver()
    {
        StopAllCoroutines();
    }

    public void GameStart()
    {
        Init();
    }
}
