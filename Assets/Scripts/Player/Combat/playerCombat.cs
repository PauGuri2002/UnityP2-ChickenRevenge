using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    [SerializeField] private bool godModeDamage; // dev tools
    [SerializeField] private AttackInfo[] attacks;
    private AttackInfo currentAttack;
    [SerializeField] private TextMeshProUGUI attackText;

    [Header("Stamina")]
    [SerializeField] private int baseStamina = 1000;
    [SerializeField] private float staminaGainPerSecond = 100;
    [SerializeField] private HealthBar staminaBar;
    [HideInInspector] public int currentStamina;

    void Start()
    {
        foreach (AttackInfo att in attacks)
        {
            att.attackScript.InitializeAttack(att.minDamage * (godModeDamage ? 3 : 1), att.maxDamage * (godModeDamage ? 3 : 1), att.cooldown, att.staminaDrain, this);
        }

        UpdateAttack(0);
        if (staminaBar != null)
        {
            staminaBar.SetBaseHealth(baseStamina);
            StartCoroutine(RecoverStamina());
        }
        currentStamina = baseStamina;
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
        currentAttack.attackScript.StartAttack();
        attackText.text = currentAttack.name;
    }

    public void UpdateStamina(int value)
    {
        if (staminaBar == null) { return; }
        currentStamina += value;
        staminaBar.SetHealth(currentStamina);
    }

    IEnumerator RecoverStamina()
    {
        while (true)
        {
            if (currentStamina < baseStamina)
            {
                UpdateStamina(1);
            }
            else
            {
                currentStamina = baseStamina;
            }
            yield return new WaitForSeconds(1 / staminaGainPerSecond);
        }
    }
}