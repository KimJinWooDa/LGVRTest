using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SupportAirPalneScript : MonoBehaviour
{
    public PaperAirPlane pap;
    public bool isGravity;
    public void SetOnMat()
    {
        pap.isGrabbed = true;
        pap.SetOnMaterial();
    }

    public void SetLine()
    {
        if(isGravity) pap.GetComponent<Rigidbody>().useGravity = true;
        pap.isThrow = true;
        pap.SetOnLine();
    }

    public void SetOffMat()
    {
        pap.isGrabbed = false;
        pap.SetOffMaterial();
    }
}
