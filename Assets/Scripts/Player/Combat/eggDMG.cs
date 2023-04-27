using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggDMG : MonoBehaviour
{
    [Header("Egg DMG")]
    [HideInInspector] public int minDamage = 10;
    [HideInInspector] public int maxDamage = 15;

    [Header("AOE Radius")]
    [SerializeField] private float aoeRadius = 2;

    [Header("Particles")]
    [SerializeField] private GameObject particles;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (!other.gameObject.CompareTag("Player") && other.GetComponent<eggDMG>() == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, aoeRadius);
            foreach (Collider c in colliders)
            {
                if (c.gameObject.GetComponent<IHealth>() != null)
                {
                    c.gameObject.GetComponent<IHealth>().TakeDamage(Random.Range(minDamage, maxDamage), gameObject);
                }
            }
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
