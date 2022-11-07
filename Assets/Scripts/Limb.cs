using System;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public RagDoll me;
    private Transform target;
    
    void Hit()
    {
        var dir = (target.position - this.transform.position);

        me.GetInfo(this.transform, dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("WEAPON"))
        {
            target = collision.collider.transform;
            Hit();
        }
    }
}
