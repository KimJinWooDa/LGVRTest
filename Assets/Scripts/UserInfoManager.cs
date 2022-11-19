using UnityEngine;

public class UserInfoManager : Singleton<UserInfoManager>
{
    public string userName;
    public Sprite[] userProfileImage;

    public int currentIndex = 0;
    
    private void Start()
    {
        currentIndex = 0;
        
    }

    public void GetUserProfileIndex(int index)
    {
        currentIndex = index;
    }

    public void GetUserName(string name)
    {
        userName = name;
    }
}
