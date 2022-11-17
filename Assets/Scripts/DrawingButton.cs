using System;
using System.Collections;
using System.Collections.Generic;
using Mono.CompilerServices.SymbolWriter;
using TMPro;
using UnityEngine;

public class DrawingButton : MonoBehaviour
{
    public GameObject table;
    private TextMeshProUGUI _textMeshProUGUI;

    private bool isOn = false;
    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DownScale()
    {
        table.transform.localScale = Vector3.zero;
        
    }
    public void Switch()
    {
        isOn = !isOn;
        InkGenerator.Instance.isOn = isOn;
    }
    private void Update()
    {
        _textMeshProUGUI.text = "Drawing Mode" + System.Environment.NewLine + (isOn ? "On" : "Off");
    }
}
