using UnityEngine;

public class KnifeKitchenCombat : MonoBehaviour
{
    [SerializeField]
    private int hitDamage = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //agafar interface en comptes de comapretag
        {
            GameObject target = other.transform.gameObject;
            IHealth targetHealth = target.GetComponent<IHealth>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(hitDamage, gameObject);
            }
        }
    }
}
