using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    public int enemyCounter = 20;
    private bool roundFinished = false;
    private int wave = 0;
    private int waves = 2;
    public override IEnumerator SpawnObject()
    {
        roundFinished = false;   
        while (!roundFinished)
        {
            for(int i=0; i<waves; i++) 
            {
                for (int z = 0; z < enemyCounter; z++)
                {
                    Instantiate(objectPrefabs[wave], new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(3);

                }
                wave++;
            }


            roundFinished = true;


        }

    }
}
