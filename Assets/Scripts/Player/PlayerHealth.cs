using System.Collections;
using UnityEngine;

public class PlayerHealth : AbstractHealth
{
    [Header("Damage parameters")]
    [SerializeField] private bool godModeHealth; // dev tools
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

    public override void TakeDamage(int damage, GameObject origin)
    {
        if (godModeHealth) { return; } // dev tools

        base.TakeDamage(damage, origin);

        if (origin != null)
        {
            Vector3 force = transform.position - origin.transform.position;
            GetHit(Vector3.Normalize(new Vector3(force.x, 0, force.z)) * pushForce);
        }

    }

    public override void Die()
    {
        base.Die();

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
