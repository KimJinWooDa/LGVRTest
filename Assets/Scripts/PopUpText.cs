using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    private Image image;
    private TextMeshProUGUI tmpo;
    private TextMeshProUGUI userName;
    private TextMeshProUGUI timeText;
    public string message;
    public string time;
    
    private void Start()
    {
        var child = this.gameObject.transform.GetChild(0);
        image = GetComponent<Image>();
        
        tmpo = child.GetChild(2).GetComponent<TextMeshProUGUI>();
        userName  = child.GetChild(1).GetComponent<TextMeshProUGUI>();
        timeText  = child.GetChild(3).GetComponent<TextMeshProUGUI>();
        image.sprite = UserInfoManager.Instance.userProfileImage[UserInfoManager.Instance.currentIndex];
       
    }

    private void Update()
    {

        tmpo.text = message;
        timeText.text = time;
    }
}
