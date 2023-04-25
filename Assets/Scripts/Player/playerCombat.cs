using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    private int currentWeapon = 0;

    [Header("Egg Shoot")]
    [SerializeField] private float shootCD = 1f;
    [HideInInspector] public bool eggShooting = true;

    [Header("Laser")]
    [SerializeField] Raycast raycastScript;

    [Header("Melee")]
    [SerializeField] private float meleeDamage = 10f;

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
            raycastScript.RaycastDMG(); 
        }

    }

    public void OnChangeWeapon(InputAction.CallbackContext context)
    {

    }

    IEnumerator ShootingEgg()
    {
        eggShooting = true;
        yield return new WaitForSeconds(shootCD);
        eggShooting = false;
    }
}
