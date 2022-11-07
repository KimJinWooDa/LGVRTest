using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject currentObject;

    public Rigidbody spine;

    public bool isDoll;

    public float power = 10000f;
    private void Start()
    {
        currentObject = this.gameObject;
    }

    public void GetInfo(Transform pos, Vector3 dir)
    {
        if (isDoll)
        {
            StartCoroutine(WaitDestroy());
            return;
        }
        var doll = Instantiate(ragdoll).GetComponent<RagDoll>();
        
        CopyTransform(currentObject.transform, doll.transform);
        
        doll.isDoll = true;
        doll.spine = pos.GetComponent<Rigidbody>();
        
        doll.spine.AddForce(dir * power, ForceMode.Impulse);
        Destroy(this.gameObject);
    } 


    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    void CopyTransform(Transform origin, Transform doll)
    {
        for (int i = 0; i < origin.childCount; i++)
        {
            if (origin.childCount != 0)
            {
                CopyTransform(origin.GetChild(i), doll.GetChild(i));
            }
            doll.GetChild(i).localPosition = origin.GetChild(i).localPosition;
            doll.GetChild(i).localRotation = origin.GetChild(i).localRotation;

        }
    }
}
