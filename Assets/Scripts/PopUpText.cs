using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public TextMeshProUGUI tmpo;
    public string message;
    private void Start()
    {
        tmpo = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmpo.text = message;
    }
}
