using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckControllerState : MonoBehaviour
{
    public enum ControllerType
    {
        left, right
    }

    public ControllerType type;
    private void OnTriggerStay(Collider other)
    {
        if (type == ControllerType.left)
        {
            if (other.CompareTag("GameController"))
            {
                other.GetComponent<EnterSwimmingZone>().checkLeftController = true;
            }
        }
        else
        {
            if (other.CompareTag("GameController"))
            {
                other.GetComponent<EnterSwimmingZone>().checkRightController = true;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (type == ControllerType.left)
        {
            if (other.CompareTag("GameController"))
            {
                other.GetComponent<EnterSwimmingZone>().checkLeftController = false;
            }
        }
        else
        {
            if (other.CompareTag("GameController"))
            {
                other.GetComponent<EnterSwimmingZone>().checkRightController = false;
            }
        }

    }
}
