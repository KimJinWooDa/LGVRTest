using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSwimmingZone : MonoBehaviour
{
    public bool checkLeftController;
    public bool checkRightController;

    public SwimmingController _swimmingController;

    private void Update()
    {
        _swimmingController.canSwmming = checkLeftController && checkRightController;
    }
}
