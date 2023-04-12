using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private float recoverTime = 2f;

    private Vector3 respawnPos;

    private CharacterController characterController;
    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        respawnPos = transform.position;
    }

    // DAMAGE & DEATH //

    Coroutine ragdollCoroutine;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("Hitter"))
        {
            //for (int i = 0; i < collision.contactCount; i++)
            //{
                Debug.Log("AH");
            //ContactPoint point = collision.GetContact(i);
            GetHit(Vector3.Normalize(transform.position - collision.transform.position) * 500f);
            //}
        }
    }

    public void Die()
    {
        Debug.Log("You died");
        characterController.enabled = false;
        transform.position = respawnPos;
        characterController.enabled = true;
    }

    public void GetHit(Vector3 hitForce)
    {
        Debug.Log("You got hit");
        if (ragdollCoroutine == null)
        {
            ragdollCoroutine = StartCoroutine(HandleRagdoll(hitForce));
        }
        else
        {
            HandleHit(hitForce);
        }
    }

    IEnumerator HandleRagdoll(Vector3 hitForce)
    {
        characterController.enabled = false;
        HandleHit(hitForce);

        yield return new WaitForSeconds(recoverTime);

        characterController.enabled = true;
        ragdollCoroutine = null;
    }

    private void HandleHit(Vector3 hitForce)
    {
        characterController.AddForce(hitForce * Time.deltaTime);
    }
}
