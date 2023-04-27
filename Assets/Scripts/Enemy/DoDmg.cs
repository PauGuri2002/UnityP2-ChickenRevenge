using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDmg : MonoBehaviour
{
    [SerializeField] private int damage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHealth>() != null && other.CompareTag("Player"))
        {
            other.GetComponent<IHealth>().TakeDamage(damage, this.gameObject);
        }
    }
}
