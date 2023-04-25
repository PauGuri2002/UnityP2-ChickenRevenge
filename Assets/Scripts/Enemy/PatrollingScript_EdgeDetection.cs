using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript_EdgeDetection : MonoBehaviour
{
    [SerializeField]
    private Transform castPoint;

    [SerializeField]
    private LayerMask whatIsGround;

    private float maxDistance = 4;

    public float speed = 5;

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
        
        if (Physics.Raycast(castPoint.position, transform.up * -1, maxDistance, whatIsGround))
        {

            return false;
        }
        return true;
    }
    private void Rotate()
    {
        float rot = Random.Range(150, 210);
        transform.Rotate(new Vector3(0, rot, 0));
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
