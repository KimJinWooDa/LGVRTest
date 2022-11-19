using TMPro;
using UnityEngine;

public class ChangeUserProfile : Singleton<ChangeUserProfile>
{
    public GameObject userProfileKeyPad;

    public TextMeshProUGUI[] userName;

    public void SetInfo()
    {
        userProfileKeyPad.SetActive(true);
        userName[0].text = null;
        userName[1].text = null;
        TextManager.Instance.isChangeProfile = true;
    }

    public void SetSuccessInfo()
    {
        userProfileKeyPad.SetActive(false);
        TextManager.Instance.isChangeProfile = false;
    }
}
