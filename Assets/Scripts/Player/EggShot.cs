using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggShot : MonoBehaviour
{
    [Header("Egg Shoot")]
    [SerializeField] private float shootCD = 1f;
    [HideInInspector] public bool eggShooting = true;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    IEnumerator ShootingEgg()
    {
        eggShooting = true;
        yield return new WaitForSeconds(shootCD);
        eggShooting = false;
    }
}
