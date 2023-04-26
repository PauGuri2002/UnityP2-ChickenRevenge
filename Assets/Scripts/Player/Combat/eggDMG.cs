using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggDMG : MonoBehaviour
{
    [Header("Egg DMG")]
    //[SerializeField] private int dmgEggDone = 20;
    [SerializeField] private int eggMaxDmg = 15;
    [SerializeField] private int eggMinDmg = 10;
    [SerializeField] private float aoeRadius = 2;
    //[SerializeField] SphereCollider hitPoint;
    //[SerializeField] SphereCollider aoePoint;

    [SerializeField] private GameObject particles;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && other.GetComponent<eggDMG>() == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, aoeRadius);
            foreach (Collider c in colliders)
            {
                if (c.gameObject.GetComponent<IHealth>() != null)
                {
                    c.gameObject.GetComponent<IHealth>().TakeDamage(Random.Range(eggMinDmg, eggMaxDmg), gameObject);
                }
            }
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
