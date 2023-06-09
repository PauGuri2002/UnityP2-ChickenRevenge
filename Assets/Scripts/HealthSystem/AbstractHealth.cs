using System;
using UnityEngine;

public class AbstractHealth : MonoBehaviour, IHealth
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _baseHealth = 100;
    [SerializeField] private int _minHealth = 0;
    private int _currentHealth;

    public static Action<int, HealthBar> OnHit;
    public static Action<GameObject> OnDie;

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
        if (_healthBar != null)
        {
            _healthBar.SetBaseHealth(_baseHealth);
        }
    }

    public virtual void TakeDamage(int damage, GameObject origin)
    {
        _currentHealth -= damage;
        if (_healthBar != null)
        {
            OnHit?.Invoke(_currentHealth, _healthBar);
        }

        //Debug.Log(_currentHealth);

        if (_currentHealth <= _minHealth)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDie?.Invoke(gameObject);
        //Debug.Log(gameObject.name + " died");
    }
}
