using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Serialization;


public class UIManager : Singleton<UIManager>
{
    [Header("키 안맞으면 offset 수치를 조정해주세요")]
    public float offset = 1f;
    
    [Header("KeyBoard위에 있는 텍스쳐 상자의 위치를 변경하고 싶으면 수치 건드세요")]
    public Vector3 chatBoxOffset;
    float height = 1f;
    
    [Space(10)]
    [Header("애니메이션시간")]
    public float InTime = 3f;
    public float OutTime = 1f;

    [Space(10)]
    [Header("애니메이션효과")]
    public Ease inAniType;
    [FormerlySerializedAs("type")] public Ease outAniType;

    [Header("UI나올 때/ 들어갈 때 Bgm")] 
    public AudioClip[] ac;
    private AudioSource _audioSource;
    
    [Space(10)]
    [Header("!!!!!아래 부터 건들No!!!!!!!!!")]
    public GameObject[] keyboard;
    [FormerlySerializedAs("player")] public Transform trace;
    public Transform rot;
    public GameObject tutorialHand;
    private bool isOn;
    private GameObject key1;
    private GameObject key2;
    
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetKeyBoard()
    {
        if (!isOn)
        {
            SetOnKeyBoard();
            _audioSource.clip = ac[0];
            _audioSource.Play();
        }
        else
        {
            _audioSource.clip = ac[1];
            _audioSource.Play();
            SetOffKeyBoard();
        }
    }

    void SetOnKeyBoard()
    {
        if (tutorialHand != null)
        {
            tutorialHand.GetComponentInChildren<TextMeshProUGUI>().text =
                "Clench your Fist to Make the KeyBoard Disappear";
        }
        isOn = true;

        key1 = Instantiate(keyboard[0], trace.position - new Vector3(0, height + offset, 0), Quaternion.identity * Quaternion.AngleAxis(rot.eulerAngles.y, Vector3.up));
        key1.transform.eulerAngles = new Vector3(30f, key1.transform.eulerAngles.y, key1.transform.eulerAngles.z);
    
         key2 = Instantiate(keyboard[1], trace.position - new Vector3(0, height + offset, 0),
            Quaternion.identity * Quaternion.AngleAxis(rot.eulerAngles.y, Vector3.up));
        
        TextManager.Instance.SetKeyBoard(key1);
        TextManager.Instance.SetTextCanvas(key2);
        

        key1.transform.DOLocalMove(new Vector3(key1.transform.position.x, height + offset, key1.transform.position.z), InTime).SetEase(inAniType);
        key2.transform.DOLocalMove(new Vector3(key2.transform.position.x+chatBoxOffset.x, height + offset + .25f + chatBoxOffset.y, key2.transform.position.z+chatBoxOffset.z), InTime).SetEase(inAniType);
    }

    void SetOffKeyBoard()
    {
        if (tutorialHand != null)
        {
            tutorialHand.SetActive(false);
        }
        isOn = false;
        key1.transform.DOLocalMove(new Vector3(key1.transform.position.x, -2f, key1.transform.position.z), OutTime).SetEase(outAniType);
        key2.transform.DOLocalMove(new Vector3(key2.transform.position.x, -2f+ .25f, key2.transform.position.z), OutTime).SetEase(outAniType);
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


