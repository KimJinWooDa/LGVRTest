using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SupportAirPalneScript : MonoBehaviour
{
    public PaperAirPlane pap;
    
    public void SetOnMat()
    {
        pap.SetOnMaterial();
    }

    public void SetLine()
    {
        pap.GetComponent<Rigidbody>().useGravity = true;
        pap.SetOnLine();
    }

    public void SetOffMat()
    {
        pap.SetOffMaterial();
    }
}
