using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasMessage : MonoBehaviour
{ 
    private TextMeshProUGUI Message;
    private string texts;
       
    public GameObject textCanvas;
    public void Awake()
    {
        Message = GetComponentInChildren<TextMeshProUGUI>();
        Message.text = null;
    }
    private void Update()
    {
        Message.text = texts;
    }
}
