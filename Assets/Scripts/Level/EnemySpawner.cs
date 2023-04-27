using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    public int enemyCounter = 1;
    public override IEnumerator SpawnObject()
    {
        for(int i = 0; i < enemyCounter; i++)
        {
            Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], new Vector3(transform.position.x, 0, transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(3);

        }
    }
}
