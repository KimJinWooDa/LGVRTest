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
            else
            {
                texts += message;
            }

        }
        else
        {
            SpawnPaperAirplane();
        }
    }

    public GameObject paperAirPlane;
    public Transform player;
    void SpawnPaperAirplane()
    {
        Destroy(keyBoard);
        Destroy(textCanvas);
       
        GameObject airPlane = Instantiate(paperAirPlane);
        airPlane.transform.position = player.position;
        airPlane.GetComponentInChildren<PaperAirPlane>().transferText = texts;
 
        texts = null;
    }
    
    private void Update()
    {
        if(textCanvas != null) Message.text = texts;
    }
}
