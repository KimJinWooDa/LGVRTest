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
     public GameObject keyboard;
    [FormerlySerializedAs("player")] public Transform trace;
    [HideInInspector] public Transform rot;
    public GameObject originTutorialHand;
    public GameObject fakeHand;
    public GameObject tutorialHand;
    [HideInInspector] public bool isOn;
    private GameObject KEYBOARD;
    [HideInInspector] public GameObject handPose;
    private bool wait;
    [HideInInspector] public bool isKeyBoardOn;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetOnHandPose()
    {
        if (!handPose.activeSelf)
        {
            handPose.SetActive(true);
            fakeHand = Instantiate(tutorialHand, trace);
            fakeHand.SetActive(true);
            //tutorialHand.SetActive(true);
        }
    }

    [HideInInspector] public bool isOnce;

    
    public void SetKeyBoard()
    {
        ChangeUserProfile.Instance.isChange = false;
        isOnce = false;
        UserInfoManager.Instance.userName = null;
        if (!wait)
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
        
    }

    void SetOnKeyBoard()
    {
        if (tutorialHand != null)
        {
            handPose.SetActive(false);
            if (originTutorialHand != null)
            {
                Destroy(originTutorialHand.gameObject);
            }

            if (fakeHand != null)
            {
                Destroy(fakeHand.gameObject);
            }
        }
        isOn = true;
        isKeyBoardOn = false;
        KEYBOARD = Instantiate(keyboard, trace.position - new Vector3(0, height + offset, 0), Quaternion.identity * Quaternion.AngleAxis(rot.eulerAngles.y, Vector3.up));
        KEYBOARD.transform.eulerAngles = new Vector3(30f, KEYBOARD.transform.eulerAngles.y, KEYBOARD.transform.eulerAngles.z);

        TextManager.Instance.KEYBOARD = this.KEYBOARD;
        TextManager.Instance.SetNormalUI(KEYBOARD);
        
        KEYBOARD.transform.DOLocalMove(new Vector3(KEYBOARD.transform.position.x, height + offset, KEYBOARD.transform.position.z), InTime).SetEase(inAniType);
        
    }

    void SetOffKeyBoard()
    {
        if(!isKeyBoardOn) handPose.SetActive(true);
        isOn = false;
        KEYBOARD.transform.DOLocalMove(new Vector3(KEYBOARD.transform.position.x, -2f, KEYBOARD.transform.position.z), OutTime).SetEase(outAniType);
 
        StartCoroutine(WaitSetOff()); //약간 수정
    }

    IEnumerator WaitSetOff()
    {
        wait = true;
        yield return new WaitForSeconds(OutTime + 0.1f);
        wait = false;
        Destroy(KEYBOARD);
    }
    
}


