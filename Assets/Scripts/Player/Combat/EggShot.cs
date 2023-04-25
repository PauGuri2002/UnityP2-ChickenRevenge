using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggShot : AbstractAttack
{
    [Header("Egg Shoot")]
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private float eggSpeed;
    [SerializeField] private int dmgEggDone;
    [SerializeField] private int eggParabolicShoot;
    [SerializeField] private float eggLiveTime;

    [SerializeField] chickenControl chickenControl;

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
        egg.GetComponent<Rigidbody>().velocity = transform.forward*-1 * eggSpeed + transform.up* eggParabolicShoot;
        //gameObject.GetComponent<IHealth>().TakeDamage(dmgEggDone, gameObject);
        StartCoroutine(DestoyEgg());
        //Destroy(egg);
        Debug.Log("enter");
    }

    IEnumerator DestoyEgg()
    {
        yield return new WaitForSeconds(eggLiveTime);
    }
}
