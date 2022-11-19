using UnityEngine;
using UnityEngine.UI;

public class UserProfile : MonoBehaviour
{
    private Image image;
    private int index;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        index = UserInfoManager.Instance.currentIndex;
        if (index >= UserInfoManager.Instance.userProfileImage.Length - 1)
        {
            index = UserInfoManager.Instance.userProfileImage.Length - 1;
        }
        image.sprite = UserInfoManager.Instance.userProfileImage[index];
    }
}
