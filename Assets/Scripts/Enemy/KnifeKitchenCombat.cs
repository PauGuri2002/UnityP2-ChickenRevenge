using UnityEngine;

public class KnifeKitchenCombat : MonoBehaviour
{
    [SerializeField]
    private int hitDamage = 10;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        IHealth targetHealth = other.transform.gameObject.GetComponent<IHealth>();
        if (targetHealth != null) //agafar interface en comptes de comapretag
        {
            targetHealth.TakeDamage(hitDamage, gameObject);
        }
    }
}
