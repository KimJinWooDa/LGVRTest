using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeUserProfile : Singleton<ChangeUserProfile>
{
    public GameObject userProfileKeyPad;

    public TextMeshProUGUI[] userName;

    public void SetInfo()
    {
        userProfileKeyPad.SetActive(true);
        TextManager.Instance.isChangeProfile = true;
    }

    public void SetSuccessInfo()
    {
        userProfileKeyPad.SetActive(false);
        TextManager.Instance.isChangeProfile = false;
    }
}
