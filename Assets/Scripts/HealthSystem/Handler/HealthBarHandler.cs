using System.Collections;
using System.Collections.Generic;
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

    private void Handle(int health, GameObject origin)
    {
        HealthBar healthBar = origin.transform.gameObject.GetComponent<HealthBar>();
        Debug.Log(healthBar.name);
        healthBar.SetHealth(health);
    }
}
