using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class ChangeFigerId : MonoBehaviour
{
    public HandJoint HandJoint;
    public HandJointId _HandJoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KEYPAD"))
        {
            HandJoint._handJointId = _HandJoint;
        }
    }
}
