using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportUserManager : MonoBehaviour
{
    public void GetUserProfileIndex(int index)
    {
        UserInfoManager.Instance.currentIndex = index;
    }
}
