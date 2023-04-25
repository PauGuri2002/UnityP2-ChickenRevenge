using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetectionScript : MonoBehaviour
{

    private Transform player;
    [SerializeField]
    [Range(0f, 30f)]
    private float minDistance = 4;

    private float FOV = 180;
    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 4;
    [SerializeField]
    private Transform castPoint;
    private Vector3 difference;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;   
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, minDistance);
       
    }
    // Update is called once per frame
    void Update()
    {
        if (IsInRange())           
        {
            Debug.Log("estas en RANGE");
            if (IsInFOV())
            {
                Debug.Log("estas en fov");


                if (!IsBlocked())
                {
                    difference =  transform.position - player.position;  
                    transform.LookAt(player.position);
                   transform.Translate(difference * speed * Time.deltaTime);
                   
                    Debug.Log("diferencia" + difference);
                    Debug.Log("Te veo");
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHealth>() != null && other.CompareTag("Player"))
        {
            other.GetComponent<IHealth>().TakeDamage(10, this.gameObject);
        }
    }
    private bool IsInFOV()
    {
        float halfFOV = FOV/2;
        Vector3 a = transform.forward;
        Vector3 b = player.position -  transform.position;
        float playerAngle = Vector3.Angle(a,b);
        return playerAngle <= halfFOV;
    }

    private bool IsInRange()
    {
        return Vector3.Distance(transform.position, player.position) < minDistance;
    }
    private bool IsBlocked()
    {
        if (Physics.Raycast(castPoint.position, Vector3.forward, minDistance, default))
        {
            Debug.Log("No t veo");

            return true;
        }
        Debug.Log("t veo");

        return false;
    }
}
