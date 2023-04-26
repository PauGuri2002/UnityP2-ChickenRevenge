using UnityEngine;

public class Boss : AbstractHealth
{
    [SerializeField] private int[] phasesHealthPercent;
    private int currentPhase = 0;

    [SerializeField] private ObjectSpawner knifeSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Renderer modelRenderer;




    public override void TakeDamage(int damage, GameObject origin)
    {
        base.TakeDamage(damage, origin);

        if (GetCurrentHealth() < phasesHealthPercent[currentPhase])
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
                break;
            case 1:
                knifeSpawner.DeactivateSpawner();
                enemySpawner.ActivateSpawner();
                ChangeColor(Color.yellow);
                break;
            case 2:
                ChangeColor(Color.red);
                break;

        }
    }

    void ChangeColor(Color color)
    {
        modelRenderer.material.SetColor("_Color", color);
    }
}
