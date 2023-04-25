using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggShot : AbstractAttack
{
    [Header("Egg Shoot")]
    [SerializeField] private float shootCD = 1f;
    [HideInInspector] public bool eggShooting = true;

    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private float eggSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void PerformAttack()
    {
        var egg = Instantiate(eggPrefab, transform.position, transform.rotation);
        egg.GetComponent<Rigidbody>().velocity = transform.forward * eggSpeed;
    }

    //IEnumerator ShootingEgg()
    //{
    //    eggShooting = true;
    //    yield return new WaitForSeconds(shootCD);
    //    eggShooting = false;
    //}

    
}
