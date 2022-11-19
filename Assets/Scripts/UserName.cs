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

    void Update()
    {
        //text.text = UserInfoManager.Instance.userName;
    }
}
