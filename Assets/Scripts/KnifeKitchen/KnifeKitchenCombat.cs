using System.Collections;
using System.Collections.Generic;
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
        if (other.CompareTag("Player"))
        {
            GameObject test = other.transform.gameObject;
            IHealth targetHealth = test.GetComponent<IHealth>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(this.hitDamage);
            }
        }
    }
}
