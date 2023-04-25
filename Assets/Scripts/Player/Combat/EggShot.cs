using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggShot : AbstractAttack
{
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
    [SerializeField] private float eggLiveTime = 6f;


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
        var egg = Instantiate(eggPrefab, transform.position, transform.rotation);

        if(eggCount <= eggMaxCount)
        {
            egg.GetComponent<Rigidbody>().velocity = transform.forward * -1 * eggSpeed + transform.up * eggParabolicShoot;
            eggCount++;
        }

        if(eggCount > eggMaxCount) // seguro que hay un código mas limpio para esta condición
        {
            for(int i = 1; i < eggNumberSpawn; i++)
            {
                var upgradedShoot = Instantiate(eggPrefab, transform.position, transform.rotation);
                upgradedShoot.GetComponent<Rigidbody>().velocity = -1 * eggSpeed * transform.forward + transform.up * eggParabolicShoot;

            }
            eggCount = 0;
        }
    }

    //IEnumerator DestoyEgg()
    //{
    //    yield return new WaitForSeconds(eggLiveTime);
    //}
}
