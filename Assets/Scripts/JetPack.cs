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

    private Vector3 rightDirection;
    private Vector3 leftDirection;
    private void FixedUpdate()
    {
        
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            rightDirection = rightHandDirectionPos.position - rightHand.position;
            rightDirection *= -1f;

            rb.AddForce(rightDirection * (jetPackPower * Time.fixedTime), ForceMode.Acceleration);
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            leftDirection = leftHand.position - leftHandDirectionPos.position;
            leftDirection *= -1f;
            rb.AddForce(leftDirection * (jetPackPower * Time.fixedTime), ForceMode.Acceleration);
        }
    }
}
