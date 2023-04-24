using System.Collections;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private int dmgRaycastDone;
    [SerializeField] private float laserRange = 50f;
    [SerializeField] private float laserDuration = 0.05f;

    LineRenderer laserLine; 

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();   
    }
    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, laserRange))
        {
            //Debug.Log(hitinfo.transform.gameObject.name);
            //Debug.Log("hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);

        }
        else
        {
            //Debug.Log("hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * laserRange, Color.green);
        }
    }
    public void RaycastDMG()
    {
        laserLine.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, laserRange))
        {
            laserLine.SetPosition(1, hitinfo.point);
            Debug.Log(hitinfo.point);
            hitinfo.collider.gameObject.GetComponent<IHealth>().TakeDamage(dmgRaycastDone, gameObject);
        }
        else
        {
            laserLine.SetPosition(1, transform.forward * laserRange + transform.position);
        }
        StartCoroutine(ShootTime());

    }

   IEnumerator ShootTime()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
