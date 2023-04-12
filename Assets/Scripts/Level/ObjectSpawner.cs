using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectPrefabs;
    [SerializeField]
    private Vector2 spawnerSize;
    [SerializeField]
    private float spawnTimeMin = 0.1f;
    [SerializeField]
    private float spawnTimeMax = 0.5f;
    [SerializeField]
    private int maxCount = 20;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Coroutine c;

    private void Start()
    {
        //ActivateSpawner();
    }

    public void ActivateSpawner()
    {
        if(c != null) { return; }
        c = StartCoroutine(SpawnFruit());
    }

    public void DeactivateSpawner()
    {
        if(c == null) { return; }
        StopCoroutine(c);
        c = null;
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));

            GameObject fruit = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            Vector3 position = transform.position + new Vector3(Random.Range(-(spawnerSize.x / 2), spawnerSize.x / 2), 0, Random.Range(-(spawnerSize.y / 2), spawnerSize.y / 2));
            spawnedObjects.Add(Instantiate(fruit, position, Quaternion.identity));

            if(spawnedObjects.Count >= maxCount)
            {
                GameObject oldestObj = spawnedObjects[0];
                spawnedObjects.Remove(oldestObj);
                Destroy(oldestObj);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnerSize.x, 0, spawnerSize.y));
    }
}
