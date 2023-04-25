using UnityEngine;

interface IHealth
{
    public void TakeDamage(int damage, GameObject origin);
    public void SetBaseHealth();
    public int GetBaseHealth();
    public int GetCurrentHealth();
}
