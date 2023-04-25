using UnityEngine;

public class Boss : AbstractHealth
{
    [SerializeField] private float[] phasesHealthPercent;
    private int currentPhase = 0;

    [SerializeField] private ObjectSpawner knifeSpawner;
    [SerializeField] private EnemySpawner enemySpawner;




    public override void TakeDamage(int damage, GameObject origin)
    {
        base.TakeDamage(damage, origin);

        int i = 0;
        foreach (float healthPercent in phasesHealthPercent)
        {
            if (GetBaseHealth() * healthPercent <= GetCurrentHealth() && currentPhase != i)
            {
                currentPhase = i;
                StartPhase();
            }

            i++;
        }
    }

    void StartPhase()
    {
        switch (currentPhase)
        {
            case 0:
                knifeSpawner.ActivateSpawner();
                break;
            case 1:
                knifeSpawner.DeactivateSpawner();
                enemySpawner.ActivateSpawner();
                break;

        }
    }
}
