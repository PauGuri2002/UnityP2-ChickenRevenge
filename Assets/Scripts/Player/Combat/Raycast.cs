using System.Collections;
using UnityEngine;

public class Raycast : AbstractAttack
{
    [Header("Laser Weapon Variables")]
    [SerializeField] private int dmgRaycastDone;
    [SerializeField] private float laserRange = 50f;
    [SerializeField] private float laserDuration = 0.05f;

    LineRenderer laserLine; 
    public override void Start()
    {
        base.Start();
        laserLine = GetComponent<LineRenderer>();
    }
    public override void PerformAttack()
    {
        laserLine.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, laserRange))
        {
            laserLine.SetPosition(1, hitinfo.point);
            //Debug.Log(hitinfo.point);
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
