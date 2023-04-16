using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private GameObject _healthBar;
    [SerializeField]
    private int _baseHealth = 100;
    [SerializeField]
    private int _minHealth = 0;

    private int _currentHealth;

    //Getters
    public int GetBaseHealth()
    {
        return _baseHealth;
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    } 

    
    public void SetBaseHealth()
    {
        _currentHealth = _baseHealth;
        _healthBar.GetComponent<HealthBar>().SetBaseHealth(_baseHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.GetComponent<HealthBar>().SetHealth(_currentHealth);
    }
}
