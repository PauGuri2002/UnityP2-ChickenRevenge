using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    [Header("Egg Shoot")]
    [SerializeField] private float shootCD = 2f;
    [HideInInspector] public bool eggShooting = true;

    [SerializeField] Raycast raycastScript;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnAttack(InputAction.CallbackContext theAttack)
    {

        if (theAttack.started) 
        { 
            Debug.Log("Button Action Enter"); 
            raycastScript.RaycastDMG(); 
        }

    }

    IEnumerator ShootingEgg()
    {
        eggShooting = true;
        yield return new WaitForSeconds(shootCD);
        eggShooting = false;
    }
}
