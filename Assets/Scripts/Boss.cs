using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AbstractHealth
{
    [HideInInspector] public float health;
    [SerializeField] private float startHealth;
    [SerializeField] private float[] phasesHealthPercent;
    private int currentPhase = 0;

    [SerializeField] private ObjectSpawner knifeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        StartPhase(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        int i = 0;
        foreach (float healthPercent in phasesHealthPercent)
        {
            if (startHealth * healthPercent <= health && currentPhase != i)
            {
                currentPhase = i;
                StartPhase();
            }

            i++;
        }
    }

    void StartPhase()
    {
        Debug.Log("Boss is starting phase " + currentPhase + 1);
        switch (currentPhase)
        {
            case 0:
                knifeSpawner.ActivateSpawner();
                break;
            case 1:
                knifeSpawner.DeactivateSpawner();
                break;
        }
    }
}
