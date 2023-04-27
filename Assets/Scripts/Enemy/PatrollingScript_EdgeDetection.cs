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
    private CharacterController Cc;


    private void Start()
    {
        Cc = gameObject.GetComponent<CharacterController>();

    }
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
            //Debug.Log("Hay suelo");
            return false;
        }
        //Debug.Log("No Hay Suelo");
        return true;
    }
    private void Rotate()
    {
        float rot = Random.Range(150, 210);
        transform.Rotate(new Vector3(0, rot, 0));
        //Debug.Log(transform.localEulerAngles.y);
    }
    private void Move()
    {
        if (Cc != null)
        {
            Cc.Move(Vector3.down + transform.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }

    }

}
