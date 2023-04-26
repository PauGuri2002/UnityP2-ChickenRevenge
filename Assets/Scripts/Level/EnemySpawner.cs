using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    public override IEnumerator SpawnObject()
    {
        while (true)
        {
            Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length - 1)], new Vector3(transform.position.x, player.position.y, transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(3);

        }
    }
}
