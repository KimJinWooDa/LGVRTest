using UnityEngine;

public class TextBgmManager : MonoBehaviour
{
    [Header("버튼 효과음")] 
    public AudioClip[] AC;

    private AudioSource AS;
    
    // [Space(10)]
    //[Header("세팅끝")]
    //
    // [Space(10)]
    // [Header("채팅창 켜질 때/꺼질 때 효과음")]
    //
    // [Space(10)]
    // [Header("종이비행기 효과음")]
    //
    // [Space(10)]
    // [Header("말풍선 나타날 때 효과음")]

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void TextBtnBgm(int index)
    {
        AS.clip = AC[index];
        AS.Play();
    }
}
