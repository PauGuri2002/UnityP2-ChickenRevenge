using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour, IHealth
{
    [SerializeField] 
    private int _maxHealth = 100;
    [SerializeField]
    private int _minHealth = 0;

    private int _currentHealth;

    //Getters
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    
    public void SetBaseHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
