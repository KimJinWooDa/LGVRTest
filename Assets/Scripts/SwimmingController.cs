using System;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class SwimmingController : MonoBehaviour
{
    [SerializeField] private float swimmingForce; 
    [SerializeField] private float resistanceForce;
    [FormerlySerializedAs("minStroke")] [SerializeField] private float minStrokeLength;
    [SerializeField] private Transform trackingSpace;

    private new Rigidbody rigidbody;
    private Vector3 currentDirection;

    public float f = 1f;
    public bool canSwmming;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        var leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        
        if (rightButtonPressed && leftButtonPressed && canSwmming)
        {
            var leftHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            var rightHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            

            var localVelocity = leftHandDirection + rightHandDirection;
            localVelocity *= -1f;
            if (localVelocity.sqrMagnitude > minStrokeLength * minStrokeLength)
            {
                AddSwimmingForce(localVelocity);
            }
        }
        // else if (leftButtonPressed) //한쪽 손으로 회전하는 방법
        // {
        //     var leftHandRotation = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
        //     float rotationForce = Vector3.Magnitude(leftHandRotation);
        //     var transformEulerAngles = transform.eulerAngles;
        //     transformEulerAngles.y += rotationForce * f;
        // }
        // else if (rightButtonPressed)
        // {
        //     var rightHandRotation = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.LTouch);
        //     float rotationForce = Vector3.Magnitude(rightHandRotation);
        //     var transformEulerAngles = transform.eulerAngles;
        //     transformEulerAngles.y += rotationForce * f;
        // }

        
       
        ApplyReststanceForce();
    }

    private void ApplyReststanceForce()
    {
        if (rigidbody.velocity.sqrMagnitude > 0.01f && currentDirection != Vector3.zero)
        {
            rigidbody.AddForce(-rigidbody.velocity * resistanceForce, ForceMode.Acceleration);
        }
        else
        {
            currentDirection = Vector3.zero;
        }
    }

    private void AddSwimmingForce(Vector3 localVelocity)
    {
        var worldSpaceVelocity = trackingSpace.TransformDirection(localVelocity);
        rigidbody.AddForce(worldSpaceVelocity * swimmingForce, ForceMode.Acceleration);
        currentDirection = worldSpaceVelocity.normalized;
    }
}
