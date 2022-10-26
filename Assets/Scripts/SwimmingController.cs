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

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch); //primary -> secondary 안됨
        var leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        if (rightButtonPressed && leftButtonPressed)
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
