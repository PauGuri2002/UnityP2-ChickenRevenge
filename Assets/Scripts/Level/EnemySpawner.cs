using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    [SerializeField] private int enemyPerWave = 20;
    [SerializeField] private Boss bossScript;
    private int wave = -1;

    public override void ActivateSpawner()
    {
        AbstractHealth.OnDie += RegisterDeath;
        Boss.OnInvincibilityStart += StartWave;
    }

    public override void DeactivateSpawner()
    {
        base.DeactivateSpawner();
        AbstractHealth.OnDie -= RegisterDeath;
        Boss.OnInvincibilityStart -= StartWave;
    }

    public override IEnumerator SpawnObject()
    {
        for (int count = 0; count < enemyPerWave; count++)
        {
            Vector3 position = transform.position + new Vector3(Random.Range(-(spawnerSize.x / 2), spawnerSize.x / 2), 0, Random.Range(-(spawnerSize.y / 2), spawnerSize.y / 2));
            GameObject newEnemy = Instantiate(objectPrefabs[wave], position, Quaternion.identity);
            spawnedObjects.Add(newEnemy);

            yield return new WaitForSeconds(0.5f);
        }
        c = null;
    }

    private void StartWave()
    {
        wave++;
        if (wave >= objectPrefabs.Length) wave = 0;
        if (c == null)
        {
            c = StartCoroutine(SpawnObject());
        }

    }

    public void RegisterDeath(GameObject deadObject)
    {
        if (spawnedObjects.Contains(deadObject))
        {
            spawnedObjects.Remove(deadObject);

            if (spawnedObjects.Count <= 0)
            {
                bossScript.SetInvincible(false);
            }
        }
    }
}
