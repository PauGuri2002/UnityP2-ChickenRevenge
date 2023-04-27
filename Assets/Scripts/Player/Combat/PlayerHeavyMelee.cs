using UnityEngine;

public class PlayerHeavyMelee : PlayerMelee
{
    [SerializeField] private GameObject particles;

    public override void PerformAttack()
    {
        animator.SetTrigger("heavy_melee");
        Invoke(nameof(DoDamage), 0.5f);
    }

    public override void DoDamage()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        base.DoDamage();
    }
}
