using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggShot : AbstractAttack
{
    [Header("Drag Point")]
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] chickenControl chickenControl;

    [Header("Egg Forces")]
    [SerializeField] private float eggSpeed = 10f;
    [SerializeField] private float eggParabolicShoot = 15f;

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
        float[] spawnDirection = { 0, 1, -1 };
        if (eggCount < eggMaxCount)
        {
            eggNumberSpawn = 1;
            eggCount++;
        }
        else
        {
            eggNumberSpawn = 3;
            eggCount = 0;
        }

        for (int i = 0; i < eggNumberSpawn; i++)
        {        
            var egg = Instantiate(eggPrefab, transform.position, transform.rotation);
            egg.GetComponent<Rigidbody>().velocity = -1 * eggSpeed * transform.forward + transform.up * eggParabolicShoot + transform.right * spawnDirection[i];
            Destroy(egg, eggLifeTime);
        }
    }
}
