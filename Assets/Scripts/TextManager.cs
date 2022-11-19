using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TextManager : Singleton<TextManager>
{
    [Header("메세지보여지기위한")]
    private TextMeshProUGUI NormalMessage;
    private GameObject noramlTextCanvas; 
    private TextMeshProUGUI SuperChatMessage;
    private GameObject SuperChatTextCanvas;

    public GameObject KEYBOARD;
    
    private string texts;
    [Space(10)]
    [Header("세팅끝")]
    public GameObject UI; //삭제하지마
    public GameObject superUI;
    
    private bool isOn;
    public void SetNormalUI(GameObject keyboard)
    {
        texts = null; //초기화
        isOn = false;
        this.noramlTextCanvas = keyboard.transform.GetChild(4).gameObject;
        NormalMessage = noramlTextCanvas.GetComponentInChildren<TextMeshProUGUI>();
        NormalMessage.text = null;
    }

    public void SetSuperChatUI(GameObject keyboard)
    {
        texts = null; //초기화
        isOn = true;
        this.SuperChatTextCanvas = keyboard.transform.GetChild(5).gameObject;
        SuperChatMessage = SuperChatTextCanvas.GetComponentInChildren<TextMeshProUGUI>();
        SuperChatMessage.text = null;
    }

    public bool isChangeProfile;
    public void GetMessage(string message)
    {
        if (isChangeProfile)
        {
            if (message == "ESC")
            {
                ChangeUserProfile.Instance.userName[0].text = ChangeUserProfile.Instance.userName[0].text.Substring(0, texts.Length - 1);
                ChangeUserProfile.Instance.userName[1].text = ChangeUserProfile.Instance.userName[1].text.Substring(0, texts.Length - 1);
            }
            if (message == "ENTER")
            {
                ChangeUserProfile.Instance.SetSuccessInfo();
                return;
            }
            ChangeUserProfile.Instance.userName[0].text += message;
            ChangeUserProfile.Instance.userName[1].text += message;
            return;
        }
        if (message == "CLOSE")
        {
            UIManager.Instance.SetKeyBoard();
            return;
        }
        if (message != "ENTER" && noramlTextCanvas != null)
        {
            if (message == "ESC")
            {
                texts = texts.Substring(0, texts.Length - 1);
            }
            else if (message == "SPACEBAR")
            {
                texts += " ";
            }
            else if (message == "CLEAR")
            {
                texts = null; //초기화
            }
            else
            {
                texts += message;
            }

        }
        else
        {
            if (UIManager.Instance.tutorialHand != null)
            {
                UIManager.Instance.tutorialHand.SetActive(false);
            }

            if (isChangeProfile)
            {
                ChangeUserProfile.Instance.SetSuccessInfo();
                return;
            }
            if(!isOn) SpawnPaperAirplane("NORMAL");
            else SpawnPaperAirplane("SUPER");
        }
    }

    [FormerlySerializedAs("paperAirPlane")] public GameObject normalAirPlane;
    public GameObject superAirPlane;
    public Transform player;
    
    public void SpawnPaperAirplane(string type)
    {
        if (KEYBOARD != null)
        {
            Destroy(KEYBOARD);
            UIManager.Instance.isOn = false;
        }

        if (type == "NORMAL")
        {
            var airPlane = Instantiate(normalAirPlane).GetComponent<PaperAirPlane>();
            airPlane.isSuper = false;
            airPlane.airPlaneType = PaperAirPlane.Type.text;
            airPlane.transform.position = player.position;
            airPlane.transferText = texts;
            airPlane.name = UserInfoManager.Instance.userName;
        }
        else if (type == "SUPER")
        {
            var airPlane = Instantiate(superAirPlane).GetComponent<PaperAirPlane>();
            airPlane.isSuper = true;
            airPlane.airPlaneType = PaperAirPlane.Type.text;
            airPlane.transform.position = player.position;
            airPlane.transferText = texts;
            airPlane.name = UserInfoManager.Instance.userName;
        }
        else if (type == "DRAW")
        {
            GameObject drawingImage = Instantiate(normalAirPlane);
            drawingImage.GetComponent<PaperAirPlane>().airPlaneType = PaperAirPlane.Type.draw;
            drawingImage.transform.position = player.position;

        }
        texts = null;
    }
    
    private void Update()
    {
        if (!isOn && NormalMessage != null) NormalMessage.text = texts;
        else if(isOn && SuperChatMessage != null) SuperChatMessage.text = texts;
    }
}
