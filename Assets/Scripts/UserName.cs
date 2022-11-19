using TMPro;
using UnityEngine;

public class UserName : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private Transform panel;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    private void Update()
    {
        
        if (!ChangeUserProfile.Instance.isChange)
        {
            if (!UIManager.Instance.isOnce)
            {
                text.text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
                panel.gameObject.SetActive(true);
            }
            else
            {
                text.text = UserInfoManager.Instance.userName;
                panel.gameObject.SetActive(false);
            }
            
        }
        else
        {
            text.text = "Enter Nickname" + System.Environment.NewLine + "(3-20)";
        }
    }
}
