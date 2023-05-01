using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDmg : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float time = 1f;

    private bool damaged = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHealth>() != null && other.CompareTag("Player"))
        {
            if(!damaged)
            {
                damaged = true;
                other.GetComponent<IHealth>().TakeDamage(damage, this.gameObject);
                StartCoroutine(DamagePlayer());
            }

        }
    }
    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(time);
        damaged = false;
    }
}
