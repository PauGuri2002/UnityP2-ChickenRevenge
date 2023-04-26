using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggDMG : MonoBehaviour
{
    [Header("Egg DMG")]
    [SerializeField] private int dmgEggDone = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IHealth>() != null)
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage(dmgEggDone, gameObject);
            Destroy(gameObject);
        }
    }
}
