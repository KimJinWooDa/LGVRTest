using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserName : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!ChangeUserProfile.Instance.isChange)
        {
            text.text = UserInfoManager.Instance.userName;
        }
        else
        {
            text.text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
        }
    }
}
