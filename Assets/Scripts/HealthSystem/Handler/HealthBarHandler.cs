using UnityEngine;

public class HealthBarHandler : MonoBehaviour
{
    void OnEnable()
    {
        AbstractHealth.OnHit += Handle;
    }

    private void OnDisable()
    {
        AbstractHealth.OnHit -= Handle;
    }

    private void Handle(int health, HealthBar healthBar)
    {
        if (healthBar == null) 
        {
            return;
        }
        
        healthBar.SetHealth(health);
    }
}
