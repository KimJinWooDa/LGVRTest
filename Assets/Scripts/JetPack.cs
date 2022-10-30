using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class JetPack : MonoBehaviour
{
    public Transform rightHand;
    public Transform leftHand;
    [FormerlySerializedAs("rightHandPos")] public Transform rightHandDirectionPos;
    [FormerlySerializedAs("leftHandPos")] public Transform leftHandDirectionPos;

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
            //var localRightHandPosition = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RHand);
            //var worldRightHandPosition = 
            var direction = rightHandDirectionPos.position - rightHand.position;
            direction *= -1f;
            rb.AddForce(direction * (jetPackPower * Time.fixedTime), ForceMode.Acceleration);
            
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            // var leftHandPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LHand);
            // var worldLeftHandPos = leftHand.TransformDirection(leftHandPosition);
            // var worldDirection  = (leftHandDirectionPos.position - worldLeftHandPos);
            //
            // rb.AddForce(worldDirection * jetPackPower, ForceMode.Acceleration);
            var direction = leftHand.position - leftHandDirectionPos.position;
            direction *= -1f;
            rb.AddForce(direction * (jetPackPower * Time.fixedTime), ForceMode.Acceleration);
        }
    }
}
