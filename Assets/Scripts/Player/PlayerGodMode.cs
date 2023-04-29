using UnityEngine;

public class PlayerGodMode : MonoBehaviour
{
    private bool godModeActive = false;
    [SerializeField] private GameObject godModeParticles;
    [SerializeField] private GameObject godModeText;
    private playerCombat playerCombat;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerCombat = GetComponent<playerCombat>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void ActivateGodMode()
    {
        if (godModeActive) { return; }

        godModeText.SetActive(false);
        playerCombat.ActivateGodMode();
        playerHealth.ActivateGodMode();
        GameObject instance = Instantiate(godModeParticles, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
        godModeActive = true;
    }
}
