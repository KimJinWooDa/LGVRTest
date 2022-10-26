using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public Transform rightDirectionPos;
    public Transform leftDirectionPos;
    public Transform trackingSpace;
    [SerializeField] private float jetPackPower = 3f;

    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            //방향을 고려해야하는데
            var rightHandPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

            var localDirection  = (rightDirectionPos.localPosition - rightHandPosition);
            var worldSpaceDirection = trackingSpace.TransformDirection(localDirection);
            rb.AddForce(worldSpaceDirection * jetPackPower, ForceMode.Acceleration);
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            var leftHandPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            var localDirection = leftDirectionPos.localPosition - leftHandPosition; 
            var worldSpaceDirection = trackingSpace.TransformDirection(localDirection);
            rb.AddForce(worldSpaceDirection * jetPackPower, ForceMode.Acceleration);
        }
    }
}
