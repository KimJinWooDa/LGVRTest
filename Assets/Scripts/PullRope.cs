using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PullRope : MonoBehaviour
{
     private bool isRightHoldedState;
     private bool canRightHoldRope; 
     private bool isLeftHoldedState;
     private bool canLeftHoldRope;

    
     private Vector3 firstRightHoldTransform; 
     private Transform holdingRightTransform;
     private Vector3 firstLeftHoldTransform;
     private Transform holdingLeftTransform;

    public Transform holdRightGrabTransform;
    public Transform holdLeftGrabTransform;
    
    private RaycastHit hit;
    [SerializeField] private float rayRange = 0.03f;
    
    private int ropeLayer;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float amplitude = 0.03f;
    [SerializeField] private float frequency = 0.01f;
    private Rigidbody rb;
    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        ropeLayer = LayerMask.NameToLayer("Rope");
    }

    private void Update()
    {
        //Debug.DrawRay(holdRightGrabTransform.position + Vector3.up*.5f, Vector3.down, Color.red);
        canRightHoldRope = Physics.Raycast(holdRightGrabTransform.position + Vector3.up*.5f, Vector3.down, out hit, rayRange, 1 << ropeLayer);
        canLeftHoldRope = Physics.Raycast(holdLeftGrabTransform.position + Vector3.up*.5f, Vector3.down, out hit, rayRange, 1 << ropeLayer);

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && canRightHoldRope)
        {
            OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch); //RTouch?
            isRightHoldedState = true;
            firstRightHoldTransform = holdRightGrabTransform.position;
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            firstRightHoldTransform = Vector3.zero;
            isRightHoldedState = false;
            holdingRightTransform = null;
        }
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && canLeftHoldRope)
        {
            OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);
            isLeftHoldedState = true;
            firstLeftHoldTransform = holdLeftGrabTransform.position;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            firstLeftHoldTransform = Vector3.zero;
            isLeftHoldedState = false;
            holdingLeftTransform = null;
        }

        if (isLeftHoldedState && isRightHoldedState) return;
        
        if (isRightHoldedState)
        {
            
            holdingRightTransform = holdRightGrabTransform;

            var dir = (firstRightHoldTransform - holdingRightTransform.position);
            //dir.x = 0;  dir.y = 0;
            var distance = Vector3.Distance(firstRightHoldTransform , holdingRightTransform.position);

            //거리만큼만 댕기면 dir 방향으로 나아가기
            transform.position += dir * (distance * speed);
            //rb.AddForce(dir * (speed * distance), ForceMode.Acceleration);
        }
        else if (isLeftHoldedState)
        {
            holdingLeftTransform = holdLeftGrabTransform;

            var dir = (firstLeftHoldTransform - holdingLeftTransform.position);
            //dir.x = 0; dir.y = 0;
            var distance = Vector3.Distance(firstLeftHoldTransform , holdingLeftTransform.position);

            transform.position += dir * (distance * speed);
            //rb.AddForce(dir * (speed * distance), ForceMode.Acceleration);
        }
    }

}
