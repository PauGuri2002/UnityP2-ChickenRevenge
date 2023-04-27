using UnityEngine;

public class EnemyHealth : AbstractHealth
{
    [HideInInspector] public bool damaged = false;

    public override void Die()
    {
        Destroy(gameObject);
    }
    public override void TakeDamage(int damage, GameObject origin)
    {
        damaged = true;
        base.TakeDamage(damage, origin);

    }
}
