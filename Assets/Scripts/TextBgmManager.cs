using UnityEngine;

public class TextBgmManager : MonoBehaviour
{
    [Header("버튼 효과음")] 
    public AudioClip[] AC;

    private AudioSource AS;

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
