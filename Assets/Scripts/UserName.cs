using TMPro;
using UnityEngine;
using DG.Tweening;
public class UserName : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private Transform panel;
    private DOTweenAnimation _doTweenAnimation;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        _doTweenAnimation = GetComponent<DOTweenAnimation>();
    }

    private void Update()
    {
        
        if (!ChangeUserProfile.Instance.isChange)
        {
            if (!UIManager.Instance.isOnce)
            {
                text.text = "Click Profile";
                if (_doTweenAnimation != null)
                {
                    _doTweenAnimation.enabled = true;
                    _doTweenAnimation.DOPlay();
                }
       
                if(panel!=null) panel.gameObject.SetActive(true);
            }
            else
            {
                text.text = UserInfoManager.Instance.userName;
                if (_doTweenAnimation != null)
                {
                    _doTweenAnimation.DOPause();
                }
      
                //panel.gameObject.SetActive(false);
            }
            
        }
        else
        {
            text.text = "Enter Nickname";
        }
        
    }
}
