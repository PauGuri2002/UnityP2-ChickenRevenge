using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    private int currentWeapon = 0;

    [SerializeField] private AbstractAttack[] attacks;
    private AbstractAttack currentAttack;

    void Start()
    {
        currentAttack = attacks[0];
    }

    void Update()
    {

    }

    public void OnAttack(InputAction.CallbackContext theAttack)
    {

        if (theAttack.started) 
        {
            currentAttack.PerformAttack();
        }

    }

    public void OnChangeWeapon(InputAction.CallbackContext context)
    {

    }

}
