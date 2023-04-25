using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    private int currentWeapon = 0;

    [Header("Egg")]
    [SerializeField] EggShot eggScript;

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

}
