using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHealth
{
    public abstract void TakeDamage(int damage);
    public abstract void SetBaseHealth();
    public abstract int GetBaseHealth();
    public abstract int GetCurrentHealth();
}
