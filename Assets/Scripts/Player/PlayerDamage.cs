using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamage : AbstractHealth
{
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private float recoverTime = 2f;

    private Vector3 respawnPos;

    private CharacterController characterController;
    private chickenControl chickenControl;

    private void Start()
    {
        base.SetBaseHealth();
        characterController = GetComponent<CharacterController>();
        chickenControl = GetComponent<chickenControl>();

        chickenControl.externalForces = Vector3.zero;
        respawnPos = transform.position;
    }

    // DAMAGE & DEATH //

    Coroutine ragdollCoroutine;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hitter"))
        {
            Vector3 force = transform.position - collision.transform.position;
            GetHit(Vector3.Normalize(new Vector3(force.x, 0, force.z)) * pushForce);
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
    }

    IEnumerator HandleRagdoll(Vector3 hitForce)
    {
        chickenControl.movementEnabled = false;
        chickenControl.externalForces = hitForce;

        yield return new WaitForSeconds(recoverTime);
        chickenControl.externalForces = Vector3.zero;

        chickenControl.movementEnabled = true;
        ragdollCoroutine = null;
    }
}
