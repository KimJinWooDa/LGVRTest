using TMPro;
using UnityEngine;

public class ChangeUserProfile : Singleton<ChangeUserProfile>
{
    public GameObject userProfileKeyPad;

    public TextMeshProUGUI[] userName;

    public void SetInfo()
    {
        userProfileKeyPad.SetActive(true);
        userName[0].text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
        userName[1].text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
        TextManager.Instance.isChangeProfile = true;
    }

    public void SetSuccessInfo()
    {
        userProfileKeyPad.SetActive(false);
        TextManager.Instance.isChangeProfile = false;
    }
}
