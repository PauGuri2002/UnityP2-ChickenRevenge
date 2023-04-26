using System;
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

    public static Action<int, GameObject> OnHit;

    //Getters
    public int GetBaseHealth() 
    {
        return _baseHealth;
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    void Start()
    {
        SetBaseHealth();
    }

    public void SetBaseHealth()
    {
        _currentHealth = _baseHealth;
        if(_healthBar != null) 
        { 
            _healthBar.GetComponent<HealthBar>().SetBaseHealth(_baseHealth); 
        }
    }

    public virtual void TakeDamage(int damage, GameObject origin)
    {
        _currentHealth -= damage;
        OnHit?.Invoke(_currentHealth, _healthBar);

        if (_currentHealth <= _minHealth)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(gameObject.name + " died");
    }
}
