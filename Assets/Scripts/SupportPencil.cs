using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportPencil : MonoBehaviour
{
    public InkGenerator ink;
    public void DrawingMode(bool isOn)
    {
        ink.isTouching = isOn;
    }
}
