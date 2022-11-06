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
    
    [SerializeField] private bool canRightPushWall;
    [SerializeField] private bool canLeftPushWall;
    private Rigidbody rb;

    private int pushWallLayer;
    [SerializeField] private float frequency = 0.01f;
    [SerializeField] private float amplitude = 0.1f;
    public Transform holdRightGrabTransform;
    public Transform holdLeftGrabTransform;

    private void Awake()
    {
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
        canRightPushWall = rightColliders.Length > 0;
        canLeftPushWall =  leftColliders.Length > 0;
        var rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        var leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

        if (canRightPushWall && rightButtonPressed)
        {
            var rightPushDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
           
            var localVelocityDirection = rightPushDirection;
            localVelocityDirection *= -1f;
            
            if (localVelocityDirection.sqrMagnitude > minPushLength * minPushLength)
            {
                OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);

                rb.AddForce(localVelocityDirection * pushOutPower, ForceMode.Impulse);
                
            }
        }
        else if (canLeftPushWall && leftButtonPressed)
        {
            var leftPushDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            var localVelocityDirection = leftPushDirection;
            localVelocityDirection *= -1f;
            if (localVelocityDirection.sqrMagnitude > minPushLength * minPushLength)
            {
                OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);
                rb.AddForce(localVelocityDirection * pushOutPower, ForceMode.Impulse);
            }
        }
    }

}
