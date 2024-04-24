using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetSpawnEnemy : MonoBehaviour
{
    [SerializeField] TextAsset[] stageRes;
    private List<EnemySpawn> spawnsL;
    [SerializeField] EnemySpawnSO[] spawnsSO;

    private void Awake() 
    {
        spawnsL = new List<EnemySpawn>();
    }

    //point, type, delay에 맞게 텍스트 읽기
    /* public void ReadSpawnFile(int value)
    {
        spawnsL.Clear();

        TextAsset textFile = stageRes[value];

        StringReader stringReader = new StringReader(textFile.text);

        while (stringReader != null) {
            string line = stringReader.ReadLine();

            if(line == null) {
                break;
            }

            EnemySpawn enemySpawnData = new()
            {
                delay = float.Parse(line.Split('/')[0]),
                type = line.Split('/')[1],
                point = int.Parse(line.Split('/')[2])
            };
            spawnsL.Add(enemySpawnData);
        }
        stringReader.Close();
    } */

    public void ReadSpawn(int value)
    {
        spawnsL.Clear();

        spawnsL = spawnsSO[value].enemySpawns;
    }

    //리스트 보네기
    public List<EnemySpawn> GetSpawnsList()
    {
        return spawnsL;
    }

}

/* public class EnemySpawn
{
    public float delay;
    public string type;
    public int point;
} */
