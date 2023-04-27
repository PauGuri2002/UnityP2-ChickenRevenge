using UnityEngine;

public class PlayerMelee : AbstractAttack
{
    [SerializeField] private float range = 2;
    public Animator animator;

    public override void PerformAttack()
    {
        animator.SetTrigger("melee");
        Invoke(nameof(DoDamage), 0.3f);
    }

    public virtual void DoDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.GetComponent<IHealth>() != null && !c.gameObject.CompareTag("Player"))
            {
                c.gameObject.GetComponent<IHealth>().TakeDamage(Random.Range(minDamage, maxDamage), gameObject);
            }
        }
    }
}
