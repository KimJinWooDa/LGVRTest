using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    
    public void GetText(String text)
    {
        TextManager.Instance.GetMessage(text);
    }

}
