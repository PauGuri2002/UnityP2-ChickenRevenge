using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    public int enemyCounter = 20;
    public override IEnumerator SpawnObject()
    {
        int wave = 0;
        for(int i = 0; i < enemyCounter; i++)
        {
            Instantiate(objectPrefabs[wave], new Vector3(transform.position.x, 0, transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(3);

        }
        wave++;
        if (wave >= objectPrefabs.Length)
        {
            wave = 0;
        }
    }
}
