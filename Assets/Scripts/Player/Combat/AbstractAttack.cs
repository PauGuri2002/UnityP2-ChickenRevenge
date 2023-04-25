using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SHOULD BE AN INTERFACE, BUT UNITY DOESN'T SUPPORT SERIALIZING INTERFACES */
public class AbstractAttack : MonoBehaviour
{
    public virtual void StartAttack() {}
    public virtual void PerformAttack() {}
    public virtual void EndAttack() {}
}
