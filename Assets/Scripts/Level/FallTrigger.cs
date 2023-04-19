using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = respawnPos;
            other.GetComponent<CharacterController>().enabled = true;

            other.GetComponent<IHealth>().TakeDamage(10);
        }
    }
}
