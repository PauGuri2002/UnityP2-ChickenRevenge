using UnityEngine;

interface IHealth
{
    public abstract void TakeDamage(int damage, GameObject origin);
    public abstract void SetBaseHealth();
    public abstract int GetBaseHealth();
    public abstract int GetCurrentHealth();
}
