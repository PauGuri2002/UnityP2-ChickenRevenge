using UnityEngine;

public class EnemyHealth : AbstractHealth
{
    [HideInInspector] public bool damaged = false;
    [SerializeField] private GameObject deathParticles;

    public override void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public override void TakeDamage(int damage, GameObject origin)
    {
        damaged = true;
        base.TakeDamage(damage, origin);

    }
}
