using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCombat : MonoBehaviour
{
    [Header("Egg Shoot")]
    [SerializeField] private float shootCD = 2f;
    [HideInInspector] public bool eggShooting = true;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnAttack(InputAction.CallbackContext theAttack)
    {

    }

    IEnumerator ShootingEgg()
    {
        eggShooting = true;
        yield return new WaitForSeconds(shootCD);
        eggShooting = false;
    }
}
