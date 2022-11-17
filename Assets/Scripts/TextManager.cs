using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextManager : Singleton<TextManager>
{
    [Header("메세지보여지기위한")]
    private TextMeshProUGUI Message;
    private string texts;
    [Space(10)]
    [Header("세팅끝")]
    public GameObject textCanvas;
    public GameObject keyBoard;
    public GameObject UI; //삭제하지마
    public void SetTextCanvas(GameObject Canvas)
    {
        this.textCanvas = Canvas;
        Message = textCanvas.GetComponentInChildren<TextMeshProUGUI>();
        Message.text = null;
    }

    public void SetKeyBoard(GameObject key)
    {
        this.keyBoard = key;
    }
    public void GetMessage(string message)
    {
        if (message == "CLOSE")
        {
            UIManager.Instance.SetKeyBoard();
            return;
        }
        if (message != "ENTER" && textCanvas != null)
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
            SpawnPaperAirplane("TEXT");
        }
    }

    public GameObject paperAirPlane;
    public Transform player;
    public void SpawnPaperAirplane(string type)
    {
        if (keyBoard != null)
        {
            Destroy(keyBoard);
            Destroy(textCanvas);
            UIManager.Instance.isOn = false;
        }

        if (type == "TEXT")
        {
            GameObject airPlane = Instantiate(paperAirPlane);
            airPlane.GetComponent<PaperAirPlane>().airPlaneType = PaperAirPlane.Type.text;
            airPlane.transform.position = player.position;
            airPlane.GetComponentInChildren<PaperAirPlane>().transferText = texts;

        }
        else if (type == "DRAW")
        {
            GameObject drawingImage = Instantiate(paperAirPlane);
            drawingImage.GetComponent<PaperAirPlane>().airPlaneType = PaperAirPlane.Type.draw;
            drawingImage.transform.position = player.position;

        }
        texts = null;
    }
    
    private void Update()
    {
        if(textCanvas != null) Message.text = texts;
    }
}
