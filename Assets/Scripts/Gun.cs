using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private SimpleShoot _simpleShoot;
    public OVRInput.Button button;
    private Grabbable _grabbable;

    private void Start()
    {
        _simpleShoot = GetComponent<SimpleShoot>();
        _grabbable = GetComponent<Grabbable>();
    }

    private void Update()
    {
        if (_grabbable.isGrabbed && OVRInput.GetDown(button))
        {
            _simpleShoot.Shoot();
        }
    }
}
