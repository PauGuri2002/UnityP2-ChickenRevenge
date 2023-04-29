using System;
using System.Collections;
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

    [Header("Shielding")]
    [SerializeField] private GameObject shield;
    [SerializeField] private float invencibilityCooldown = 5;
    private Coroutine waitCoroutine;

    private CapsuleCollider bossCollider;
    private PatrollingScript patrollingScript;

    public static Action OnInvincibilityEnd;
    public static Action OnInvincibilityStart;

    private void OnEnable()
    {
        patrollingScript = GetComponent<PatrollingScript>();
        bossCollider = GetComponent<CapsuleCollider>();
        ChangeColor(Color.green);
    }

    public override void TakeDamage(int damage, GameObject origin)
    {
        base.TakeDamage(currentPhase > 1 ? (int)Mathf.Round(damage / 1.5f) : damage, origin);

        if (currentPhase < phasesHealthPercent.Length && GetCurrentHealth() < phasesHealthPercent[currentPhase])
        {
            StartPhase();
            currentPhase++;
        }
    }

    void StartPhase()
    {
        Debug.Log("Boss phase " + (currentPhase + 1));
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
        SetInvincible(true);
        _animator.SetInteger("Phase", currentPhase);
    }

    private void ThirdPhase()
    {
        knifeSpawner.ActivateSpawner();
        ChangeColor(Color.red);
        SetPhasePatrollingSpeed();

        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }
        SetInvincible(true);

        _animator.SetInteger("Phase", currentPhase);
    }

    private void SetPhasePatrollingSpeed()
    {
        int index = currentPhase < phasesPatrollingSpeed.Length ? currentPhase : phasesPatrollingSpeed.Length - 1;
        patrollingScript.speed = phasesPatrollingSpeed[index];
    }

    public override void Die()
    {
        knifeSpawner.DeactivateSpawner();
        enemySpawner.DeactivateSpawner();
        knifeSpawner.DestroyAll();
        enemySpawner.DestroyAll();
        ChangeColor(Color.black);
        patrollingScript.speed = 0;

        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }

        _animator.SetBool("die", true);
        base.Die();
    }

    void ChangeColor(Color color)
    {
        modelRenderer.material.SetColor("_Color", color);
    }

    public void SetInvincible(bool isInvincible)
    {
        if (isInvincible)
        {
            shield.SetActive(true);
            bossCollider.enabled = false;
            patrollingScript.speed = 0;

            OnInvincibilityStart?.Invoke();
        }
        else
        {
            shield.SetActive(false);
            bossCollider.enabled = true;
            SetPhasePatrollingSpeed();

            OnInvincibilityEnd?.Invoke();
            waitCoroutine = StartCoroutine(WaitInvincibility());
        }
    }

    IEnumerator WaitInvincibility()
    {
        yield return new WaitForSeconds(invencibilityCooldown);
        SetInvincible(true);
        waitCoroutine = null;
    }
}
