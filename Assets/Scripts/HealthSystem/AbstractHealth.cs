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

    void Start()
    {
        Debug.Log(_baseHealth);
    }

    public void SetBaseHealth()
    {
        _currentHealth = _baseHealth;
        _healthBar.GetComponent<HealthBar>().SetBaseHealth(_baseHealth);
    }

    public virtual void TakeDamage(int damage, GameObject origin)
    {
        _currentHealth -= damage;
        if (_healthBar != null) { _healthBar.GetComponent<HealthBar>().SetHealth(_currentHealth); }

        Debug.Log(gameObject.name + " health: " + _currentHealth);

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
