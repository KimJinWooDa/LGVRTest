using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportKeyPad : MonoBehaviour
{
    public int padID;
    void Update()
    {
        if (padID == UserInfoManager.Instance.currentIndex)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
