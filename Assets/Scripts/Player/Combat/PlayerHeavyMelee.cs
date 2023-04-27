using UnityEngine;

public class PlayerHeavyMelee : AbstractAttack
{
    [SerializeField] private float aoe = 6;
    [SerializeField] private Animator animator;

    public override void PerformAttack()
    {
        animator.SetTrigger("heavy_melee");
        Invoke(nameof(DoDamage), 0.5f);
    }

    void DoDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, aoe);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.GetComponent<IHealth>() != null && !c.gameObject.CompareTag("Player"))
            {
                c.gameObject.GetComponent<IHealth>().TakeDamage(Random.Range(minDamage, maxDamage), gameObject);
            }
        }
    }
}
