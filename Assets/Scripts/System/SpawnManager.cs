using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] positions;
    public EnemyMove PrefabA;
    public GameObject spawnA;
    public GameObject spawnB;
    public GameObject spawnC;
    bool spawnAUsed;
    bool spawnBUsed;
    bool spawnCUsed;

    void Update ()
    {
        if (spawnA == null &&  spawnAUsed == false)
        {
            EnemyMove enemyTempA = Instantiate(PrefabA);
            enemyTempA.transform.position = positions[0].position;
            EnemyMove enemyTempB = Instantiate(PrefabA);
            enemyTempB.transform.position = positions[1].position;
            spawnAUsed = true;
        }
        if (spawnB == null &&  spawnBUsed == false)
        {
            EnemyMove enemyTempC = Instantiate(PrefabA);
            enemyTempC.transform.position = positions[2].position;
            EnemyMove enemyTempD = Instantiate(PrefabA);
            enemyTempD.transform.position = positions[3].position;
            spawnBUsed = true;
        }
        if (spawnC == null &&  spawnCUsed == false)
        {
            EnemyMove enemyTempE = Instantiate(PrefabA);
            enemyTempE.transform.position = positions[4].position;
            EnemyMove enemyTempF = Instantiate(PrefabA);
            enemyTempF.transform.position = positions[5].position;
            spawnCUsed = true;
        }
    }
}
