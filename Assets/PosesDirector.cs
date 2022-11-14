using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;

public class PosesDirector : MonoBehaviour
{
    public List<ActiveStateSelector> activeState;
    public TextMeshProUGUI text;

    private void Start()
    {
        foreach (var item in activeState)
        {
            item.WhenSelected += () => SetText(item.gameObject.name);
            item.WhenUnselected += () => SetText("");
        }
    }

    void SetText(string newText)
    {
        text.text = newText;
    }
}
