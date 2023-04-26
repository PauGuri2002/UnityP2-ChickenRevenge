using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggDMG : MonoBehaviour
{
    [Header("Egg DMG")]
    [SerializeField] private int dmgEggDone = 20;

    [SerializeField] private GameObject particles;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<IHealth>() != null)
        {
            other.gameObject.GetComponent<IHealth>().TakeDamage(dmgEggDone, gameObject);
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (!other.gameObject.CompareTag("Player") && other.GetComponent<eggDMG>() == null)
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
