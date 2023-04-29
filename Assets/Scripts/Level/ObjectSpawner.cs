using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public Vector2 spawnerSize;
    public float spawnerHeight;
    [SerializeField]
    private float spawnTimeMin = 0.1f;
    [SerializeField]
    private float spawnTimeMax = 0.5f;
    [SerializeField]
    private int maxCount = 20;
    [SerializeField]
    private bool followPlayer = true;

    [HideInInspector] public List<GameObject> spawnedObjects = new List<GameObject>();
    [HideInInspector] public Coroutine c;
    [HideInInspector] public Transform player;

    private void Start()
    {
        player = FindObjectOfType<chickenControl>().transform;
    }

    public virtual void ActivateSpawner()
    {
        if (c != null) { return; }
        c = StartCoroutine(SpawnObject());
    }

    public virtual void DeactivateSpawner()
    {
        if (c == null) { return; }
        StopCoroutine(c);
        c = null;
    }

    public virtual IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));

            GameObject fruit = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            Vector3 position;
            if (!followPlayer)
            {
                position = new Vector3(transform.position.x, spawnerHeight, transform.position.z) + new Vector3(Random.Range(-(spawnerSize.x / 2), spawnerSize.x / 2), 0, Random.Range(-(spawnerSize.y / 2), spawnerSize.y / 2));
            }
            else
            {
                position = new Vector3(player.position.x, spawnerHeight, player.position.z);
            }


            spawnedObjects.Add(Instantiate(fruit, position, Quaternion.identity));

            if (spawnedObjects.Count >= maxCount)
            {
                GameObject oldestObj = spawnedObjects[0];
                spawnedObjects.Remove(oldestObj);
                Destroy(oldestObj);
            }
        }
    }

    public void DestroyAll()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, spawnerHeight, transform.position.z), new Vector3(spawnerSize.x, 0, spawnerSize.y));
    }
}
