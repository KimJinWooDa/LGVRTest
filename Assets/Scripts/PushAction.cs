using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAction : MonoBehaviour
{
    [SerializeField] private float pushOutPower;
    [SerializeField] private float minPushLength;
    [SerializeField] private float rayRange = 0.7f;
    [SerializeField] private float waterFriction = 0.07f;
    
    [SerializeField] private bool canPushWall;

    private Rigidbody rb;
    private int seaRidgeLayer;
    private int pushWallLayer;
    [SerializeField] private float frequency = 0.01f;
    [SerializeField] private float amplitude = 0.1f;
    public Transform holdRightGrabTransform;
    public Transform holdLeftGrabTransform;

    private void Awake()
    {
        seaRidgeLayer = LayerMask.NameToLayer("SeaRidge");
        rb = GetComponent<Rigidbody>();
        pushWallLayer = LayerMask.NameToLayer("SeaRidge");
    }

    private void FixedUpdate()
    {
        //canPushWall = Physics.Raycast(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),Vector3.forward, rayRange, 1 << seaRidgeLayer) &&
        //Physics.Raycast(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch), Vector3.forward, rayRange, 1<< seaRidgeLayer);
        Collider[] rightColliders =
            Physics.OverlapSphere(holdRightGrabTransform.position, rayRange,
                1 << pushWallLayer);
        Collider[] leftColliders =
            Physics.OverlapSphere(holdLeftGrabTransform.position, rayRange,
                1 << pushWallLayer);
        canPushWall = rightColliders.Length > 0 && leftColliders.Length > 0;
        var rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        var leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

        if (canPushWall && rightButtonPressed && leftButtonPressed)
        {
            var rightPushDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            var leftPushDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);

            var localVelocityDirection = rightPushDirection + leftPushDirection;
            localVelocityDirection *= -1f;
            
            if (localVelocityDirection.sqrMagnitude > minPushLength * minPushLength)
            {
                OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
                OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);
                rb.AddForce(localVelocityDirection * pushOutPower, ForceMode.Impulse);
                print(localVelocityDirection * pushOutPower);
            }
        }
        //ApplyReststanceForce(); //already exist resistanceForce in swimmingController.cs
    }

    void ApplyReststanceForce()
    {
        if (rb.velocity.sqrMagnitude > 0.01f)
        {
            rb.AddForce(-rb.velocity * waterFriction, ForceMode.Acceleration);
        }
        
    }
}
