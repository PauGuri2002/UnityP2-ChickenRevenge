using UnityEngine;

public class AbstractAttack : MonoBehaviour
{
    [HideInInspector] public float cooldown = 0.5f;
    [HideInInspector] public int minDamage = 10;
    [HideInInspector] public int maxDamage = 15;
    [HideInInspector] public int staminaDrain = 10;
    private float timeFire;
    private playerCombat playerCombat;

    public void InitializeAttack(int _minDamage, int _maxDamage, float _cooldown, int _staminaDrain, playerCombat _playerCombat)
    {
        cooldown = _cooldown;
        minDamage = _minDamage;
        maxDamage = _maxDamage;
        staminaDrain = _staminaDrain;
        playerCombat = _playerCombat;

        timeFire = cooldown;
    }

    public virtual void StartAttack() { }
    public virtual void PerformAttack() { }
    public virtual void EndAttack() { }
    public virtual void Update()
    {
        if (cooldown >= timeFire)
        {
            timeFire += Time.deltaTime;
        }
    }
    public void TryPerformAttack()
    {
        if (timeFire > cooldown)
        {
            PerformAttack();
            timeFire = 0f;
            if (staminaDrain > 0)
            {
                playerCombat.UpdateStamina(staminaDrain * -1);
            }
        }
    }
}

