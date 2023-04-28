using UnityEngine;

public class Boss : AbstractHealth
{
    [SerializeField] private int[] phasesHealthPercent;
    [SerializeField] private float[] phasesPatrollingSpeed;
    private int currentPhase = 0;

    [SerializeField] private ObjectSpawner knifeSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Renderer modelRenderer;
    [SerializeField] private Animator _animator;
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
                FirstPhase();
                break;
            case 1:
                SecondPhase();
                break;
            case 2:
                ThirdPhase();
                break;
        }
    }

    private void FirstPhase() 
    {
        knifeSpawner.ActivateSpawner();
        ChangeColor(Color.green);
        SetPhasePatrollingSpeed();
        _animator.SetInteger("Phase", currentPhase);

    }

    private void SecondPhase() 
    {
        knifeSpawner.DeactivateSpawner();
        knifeSpawner.DestroyAll();
        enemySpawner.ActivateSpawner();
        ChangeColor(Color.yellow);
        SetPhasePatrollingSpeed();
        _animator.SetInteger("Phase", currentPhase);
    }

    private void ThirdPhase()
    {
        knifeSpawner.ActivateSpawner();
        ChangeColor(Color.red);
        SetPhasePatrollingSpeed();
        _animator.SetInteger("Phase", currentPhase);
    }

    private void SetPhasePatrollingSpeed() 
    {
        patrollingScript.speed = phasesPatrollingSpeed[currentPhase];
    }

    public override void Die()
    {
        knifeSpawner.DeactivateSpawner();
        enemySpawner.DeactivateSpawner();
        knifeSpawner.DestroyAll();
        ChangeColor(Color.black);
        patrollingScript.speed = 0;
        _animator.SetBool("die", true);
    }

    void ChangeColor(Color color)
    {
        modelRenderer.material.SetColor("_Color", color);
    }
}
