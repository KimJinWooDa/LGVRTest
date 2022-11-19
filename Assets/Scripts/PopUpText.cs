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
    public string name;
    public Sprite profile;
    private void Start()
    {
        var child = this.gameObject.transform.GetChild(0);
        image = child.GetComponentInChildren<Image>();
        tmpo = child.GetChild(2).GetComponent<TextMeshProUGUI>();
        userName  = child.GetChild(1).GetComponent<TextMeshProUGUI>();
        timeText  = child.GetChild(3).GetComponent<TextMeshProUGUI>();

    }

    public void GetInfo()
    {
        image.sprite = profile;
        userName.text = name;
        tmpo.text = message;
        timeText.text = time;
    }

}
