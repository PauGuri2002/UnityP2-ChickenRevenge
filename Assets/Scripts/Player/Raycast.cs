using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hitinfo, 999f))
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
}
