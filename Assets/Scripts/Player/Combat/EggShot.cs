using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggShot : AbstractAttack
{
    [Header("Draggable Things")]
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] chickenControl chickenControl;

    [Header("Egg Forces")]
    [SerializeField] private float eggSpeed = 10f;
    [SerializeField] private float eggParabolicShoot = 15f;

    [Header("Egg DMG")]
    [SerializeField] private int dmgEggDone = 20;

    [Header("Egg Hidden Secret")]
    [SerializeField] private float eggMaxCount = 5;
    [SerializeField] private int eggNumberSpawn = 3;
    private float eggCount = 0;

    [Header("Egg Destroy")]
    [SerializeField] private float eggLifeTime = 6f;
    public override void StartAttack()
    {
        base.StartAttack();
        chickenControl.rotationChicken = 180f;
    }
    public override void EndAttack()
    {
        base.EndAttack();
        chickenControl.rotationChicken = 0f;
    }
    public override void PerformAttack() 
    {
        if (eggCount < eggMaxCount)
        {
            var egg = Instantiate(eggPrefab, transform.position, transform.rotation);
            egg.GetComponent<Rigidbody>().velocity = -1 * eggSpeed * transform.forward + transform.up * eggParabolicShoot;
            eggCount++;
            Destroy(egg, eggLifeTime);
        }

        if(eggCount == eggMaxCount)
        {
            for(int i = 1; i < eggNumberSpawn; i++)
            {
                var upgradedShoot = Instantiate(eggPrefab, transform.position, transform.rotation);
                upgradedShoot.GetComponent<Rigidbody>().velocity = -1 * eggSpeed * transform.forward + transform.up * eggParabolicShoot;
                Destroy(upgradedShoot, eggLifeTime);
            }
            eggCount = 0;
        }
    }
}
