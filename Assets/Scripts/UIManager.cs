using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;


public class UIManager : MonoBehaviour
{
    [Header("키 안맞으면 offset 수치를 조정해주세요")]
    float height = 1f;
    public float offset = 1f;
    
    [Space(10)]
    [Header("애니메이션시간")]
    public float InTime = 3f;
    public float OutTime = 1f;

    [Space(10)]
    [Header("애니메이션효과")]
    public Ease inAniType;
    [FormerlySerializedAs("type")] public Ease outAniType;
    
    [Header("건들No")]
    public GameObject[] keyboard;
    [FormerlySerializedAs("player")] public Transform trace;
    public Transform rot;
    private bool isOn;
    private GameObject key1;
    private GameObject key2;
   
    public void SetKeyBoard()
    {
        if (!isOn)
        {
            SetOnKeyBoard();
        }
        else
        {
            SetOffKeyBoard();
        }
    }

    void SetOnKeyBoard()
    {
        isOn = true;

        key1 = Instantiate(keyboard[0], trace.position - new Vector3(0, height + offset, 0), Quaternion.identity * Quaternion.AngleAxis(rot.eulerAngles.y, Vector3.up));
        key1.transform.eulerAngles = new Vector3(30f, key1.transform.eulerAngles.y, key1.transform.eulerAngles.z);
    
         key2 = Instantiate(keyboard[1], trace.position - new Vector3(0, height + offset, 0),
            Quaternion.identity * Quaternion.AngleAxis(rot.eulerAngles.y, Vector3.up));
        
        TextManager.Instance.SetKeyBoard(key1);
        TextManager.Instance.SetTextCanvas(key2);
        

        key1.transform.DOLocalMove(new Vector3(key1.transform.position.x, height + offset, key1.transform.position.z), InTime).SetEase(inAniType);
        key2.transform.DOLocalMove(new Vector3(key2.transform.position.x, height + offset + .4f, key2.transform.position.z), InTime).SetEase(inAniType);
    }

    void SetOffKeyBoard()
    {
        isOn = false;
        key1.transform.DOLocalMove(new Vector3(key1.transform.position.x, -2f, key1.transform.position.z), OutTime).SetEase(outAniType);
        key2.transform.DOLocalMove(new Vector3(key2.transform.position.x, -2f+ .4f, key2.transform.position.z), OutTime).SetEase(outAniType);
        StartCoroutine(WaitSetOff());
    }

    IEnumerator WaitSetOff()
    {
        yield return new WaitForSeconds(OutTime + 0.1f);
        Destroy(key1);
        Destroy(key2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetKeyBoard();
        }
    }
}


