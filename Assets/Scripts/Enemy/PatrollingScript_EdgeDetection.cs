using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript_EdgeDetection : MonoBehaviour
{
    [SerializeField]
    private Transform castPoint;

    [SerializeField]
    private LayerMask whatIsGround;

    private float maxDistance = 2;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
        {
            Rotate();
        }
        Move();
    }
    private bool EdgeDetected()
    {
        if (Physics.Raycast(castPoint.position, Vector3.down, maxDistance, whatIsGround))
        {
            return false;
        }
        return true;
    }
    private void Rotate()
    {
        float rot = Random.Range(90,270);
        transform.Rotate(new Vector3(0, rot, 0));
        transform.localEulerAngles = new Vector3(0, rot,0);    
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
