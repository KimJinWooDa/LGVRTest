using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportPencil : MonoBehaviour
{
    public InkGenerator ink;
    public GameObject[] bubbles;
    
    public void DrawingMode(bool isOn)
    {
        bubbles[0].SetActive(false);
        bubbles[1].SetActive(true);
        ink.isTouching = isOn;
    }
}
