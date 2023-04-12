using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private float recoverTime = 2f;

    private Vector3 respawnPos;

    private CharacterController characterController;
    private PlayerInput playerInput;
    private chickenControl chickenControl;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        chickenControl = GetComponent<chickenControl>();

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
        chickenControl.movementEnabled = false;
        HandleHit(hitForce);

        yield return new WaitForSeconds(recoverTime);

        chickenControl.movementEnabled = true;
        ragdollCoroutine = null;
    }

    private void HandleHit(Vector3 hitForce)
    {
        chickenControl.externalForce = (hitForce * Time.deltaTime);
    }
}
