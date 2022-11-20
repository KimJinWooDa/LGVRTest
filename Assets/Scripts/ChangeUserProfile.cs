using TMPro;
using UnityEngine;

public class ChangeUserProfile : Singleton<ChangeUserProfile>
{
    public GameObject userProfileKeyPad;

    public TextMeshProUGUI[] userName;

    public bool isChange;
    public void SetInfo()
    {
        UserInfoManager.Instance.userName = null;
        TextManager.Instance.isOnce = false;
        //TextManager.Instance.GetMessage(" ");
        userProfileKeyPad.SetActive(true);
        TextManager.Instance.isChangeProfile = true;
        isChange = true;
    }

    public void SetSuccessInfo()
    {
        userProfileKeyPad.SetActive(false);
        TextManager.Instance.isChangeProfile = false;
    }

    public void SetDoneInfo()
    {
        TextManager.Instance.ChangeProfile();
        isChange = false;
    }
}
