using TMPro;
using UnityEngine;

public class ChangeUserProfile : Singleton<ChangeUserProfile>
{
    public GameObject userProfileKeyPad;

    public TextMeshProUGUI[] userName;

    public void SetInfo()
    {
        TextManager.Instance.isOnce = false;
        userProfileKeyPad.SetActive(true);
        userName[0].text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
        userName[0].color = new Color(255f, 255f, 255f, 70f);
        userName[1].text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
        userName[1].color = new Color(255f, 255f, 255f, 70f);
        TextManager.Instance.isChangeProfile = true;
    }

    public void SetSuccessInfo()
    {
        userProfileKeyPad.SetActive(false);
        TextManager.Instance.isChangeProfile = false;
    }

    public void SetDoneInfo()
    {
        TextManager.Instance.ChangeProfile();
    }
}
