using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hitinfo, 20f))
        {
            //Debug.Log(hitinfo.transform.gameObject.name);
            //Debug.Log("hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hitinfo.distance, Color.red);

        }
        else
        {
            //Debug.Log("hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 20f, Color.green);
        }
    }
    public void RaycastDMG()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hitinfo, 20f))
        {   
            hitinfo.collider.gameObject.GetComponent<IHealth>().TakeDamage(10);
        }

    }
}
