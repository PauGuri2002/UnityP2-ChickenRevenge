using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
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
            currentAttack.TryPerformAttack();
        }
    }

    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.started) {
            currentAttack.EndAttack();

            int currentIndex = Array.IndexOf(attacks, currentAttack);
            float offset = context.ReadValue<Vector2>().y;

            int newIndex = currentIndex + (offset > 0 ? 1 : -1);
            if(newIndex < 0)
            {
                newIndex = attacks.Length - 1;
            }
            if(newIndex >= attacks.Length)
            {
                newIndex = 0;
            }
            currentAttack = attacks[newIndex];
            currentAttack.StartAttack();

            Debug.Log("Current attack: " + newIndex);
        }
    }
}
