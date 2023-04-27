using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractAttack : MonoBehaviour
{
    [HideInInspector] public float cooldown = 0.5f;
    [HideInInspector] public int minDamage = 10;
    [HideInInspector] public int maxDamage = 15;
    private float timeFire;

    public virtual void StartAttack(int _minDamage, int _maxDamage, float _cooldown) {
        cooldown = _cooldown;
        minDamage = _minDamage;
        maxDamage = _maxDamage;
    }
    public virtual void PerformAttack() {}
    public virtual void EndAttack() {}

    
    public virtual void Start()
    {
        timeFire = cooldown;
    }
    public virtual void Update()
    {
        if (cooldown >= timeFire)
        {
            timeFire += Time.deltaTime;
        }
    }
    public void TryPerformAttack()
    {
        if(timeFire > cooldown)
        {
            PerformAttack();
            timeFire = 0f;
        }
    }
}

