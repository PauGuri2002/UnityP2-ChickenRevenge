using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    [SerializeField] private AttackInfo[] attacks;
    private AttackInfo currentAttack;
    [SerializeField] private TextMeshProUGUI attackText;

    void Start()
    {
        UpdateAttack(0);
    }
    void Update()
    {

    }
    public void OnAttack(InputAction.CallbackContext theAttack)
    {
        if (theAttack.started)
        {
            currentAttack.attackScript.TryPerformAttack();
        }
    }
    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentAttack.attackScript.EndAttack();

            int currentIndex = Array.IndexOf(attacks, currentAttack);
            float offset = context.ReadValue<Vector2>().y;

            int newIndex = currentIndex + (offset > 0 ? 1 : -1);
            if (newIndex < 0)
            {
                newIndex = attacks.Length - 1;
            }
            if (newIndex >= attacks.Length)
            {
                newIndex = 0;
            }
            UpdateAttack(newIndex);
        }
    }

    void UpdateAttack(int index)
    {
        currentAttack = attacks[index];
        currentAttack.attackScript.StartAttack(attacks[index].minDamage, attacks[index].maxDamage, attacks[index].cooldown);
        attackText.text = currentAttack.name;
    }
}