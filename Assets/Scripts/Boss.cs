using UnityEngine;

public class Boss : AbstractHealth
{
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

    public override void TakeDamage(int damage, GameObject origin)
    {
        base.TakeDamage(damage, origin);

        int i = 0;
        foreach (float healthPercent in phasesHealthPercent)
        {
            if (GetBaseHealth() * healthPercent <= GetCurrentHealth() && currentPhase != i)
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
