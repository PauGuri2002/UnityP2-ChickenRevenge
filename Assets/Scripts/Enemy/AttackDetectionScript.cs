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
    private Animator animator;
    private CharacterController Cc;
    [SerializeField] private GameObject mano;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;  
        animator = GetComponent<Animator>();
        Cc = gameObject.GetComponent<CharacterController>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, minDistance);
       
    }
    // Update is called once per frame
    void Update()
    {

        ChecknAttack();
        
    }

    private void ChecknAttack()
    {
        animator.SetBool("IsChasing", false);
        mano.GetComponent<BoxCollider>().enabled = false;
        if (IsInRange())
        {
            if (IsInFOV())
            {


                if (!IsBlocked())
                {
                    mano.GetComponent<BoxCollider>().enabled = true;
                    animator.SetBool("IsChasing",true);
                    difference = transform.position - player.position;
                    transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                    Cc.Move(new Vector3(difference.x * speed * Time.deltaTime, -9.8f, difference.z * speed * Time.deltaTime));

                }
            }
        }
        else if(gameObject.GetComponent<EnemyHealth>().damaged)
        {
            difference = player.position - transform.position  ;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            Cc.Move(new Vector3(difference.x * (speed / 10) * Time.deltaTime, -9.8f, difference.z * speed * Time.deltaTime));
            
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

            return true;
        }

        return false;
    }
}
