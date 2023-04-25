using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SHOULD BE AN INTERFACE, BUT UNITY DOESN'T SUPPORT SERIALIZING INTERFACES */
public class AbstractAttack : MonoBehaviour
{
    public virtual void StartAttack() {}
    public virtual void PerformAttack() {}
    public virtual void EndAttack() {}

    [Header("TimerCD")]
    [SerializeField] private float fireRate = 0.5f;
    private float timeFire;

    public virtual void Start()
    {
        timeFire = fireRate;
    }

    public virtual void Update()
    {
        if (fireRate >= timeFire)
        {
            timeFire += Time.deltaTime;
        }
    }

    public void TryPerformAttack()
    {
        if(timeFire > fireRate)
        {
            PerformAttack();
            timeFire = 0f;
        }
    }

}

