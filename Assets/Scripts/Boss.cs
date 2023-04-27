using UnityEngine;

public class Boss : AbstractHealth
{
    [SerializeField] private int[] phasesHealthPercent;
    [SerializeField] private float[] phasesPatrollingSpeed;
    private int currentPhase = 0;

    [SerializeField] private ObjectSpawner knifeSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Renderer modelRenderer;

    private PatrollingScript patrollingScript;

    private void OnEnable()
    {
        patrollingScript = GetComponent<PatrollingScript>();
    }

    public override void TakeDamage(int damage, GameObject origin)
    {
        base.TakeDamage(currentPhase > 1 ? (int) Mathf.Round(damage / 1.5f) : damage, origin);

        if (currentPhase < phasesHealthPercent.Length && GetCurrentHealth() < phasesHealthPercent[currentPhase])
        {
            StartPhase();
            currentPhase++;
        }
    }

    void StartPhase()
    {
        switch (currentPhase)
        {
            case 0:
                knifeSpawner.ActivateSpawner();
                ChangeColor(Color.green);
                patrollingScript.speed = phasesPatrollingSpeed[0];
                break;
            case 1:
                knifeSpawner.DeactivateSpawner();
                knifeSpawner.DestroyAll();
                enemySpawner.ActivateSpawner();
                ChangeColor(Color.yellow);
                patrollingScript.speed = phasesPatrollingSpeed[1];
                break;
            case 2:
                knifeSpawner.ActivateSpawner();
                ChangeColor(Color.red);
                patrollingScript.speed = phasesPatrollingSpeed[2];
                break;
        }
    }

    public override void Die()
    {
        knifeSpawner.DeactivateSpawner();
        enemySpawner.DeactivateSpawner();
        knifeSpawner.DestroyAll();
        ChangeColor(Color.black);
        patrollingScript.speed = 0;
    }

    void ChangeColor(Color color)
    {
        modelRenderer.material.SetColor("_Color", color);
    }
}
