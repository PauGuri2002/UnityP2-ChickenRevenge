using UnityEngine;

public class HitterHandler : MonoBehaviour
{
    [SerializeField]
    private float pushForce = 30f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerDamage pd = collision.gameObject.GetComponent<PlayerDamage>();
        
        if (pd != null)
        {
            for(int i = 0; i < collision.contactCount; i++)
            {
                Debug.Log("AH");
                ContactPoint point = collision.GetContact(i);
                pd.GetHit(rb.GetPointVelocity(point.point) * pushForce);
            }
        }
    }
}
