using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : AbstractHealth
{
    private bool godModeHealth = false; // dev tools

    [Header("Damage parameters")]
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private float recoverTime = 2f;
    [SerializeField] private GameObject deadText;
    private chickenControl chickenControl;

    private void Start()
    {
        base.SetBaseHealth();
        chickenControl = GetComponent<chickenControl>();

        chickenControl.externalForces = Vector3.zero;
        deadText.SetActive(false);
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
        Animator playerAnimator = chickenControl._playerAnimator;

        playerAnimator.SetBool("die", true);
        chickenControl.movementEnabled = false;
        deadText.SetActive(true);

        if (ragdollCoroutine != null)
        {
            StopCoroutine(ragdollCoroutine);
        }
        Invoke("ReloadScene", 5f);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
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

    public void ActivateGodMode()
    {
        godModeHealth = true;
    }
}
