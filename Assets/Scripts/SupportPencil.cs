using UnityEngine;

public class SupportPencil : MonoBehaviour
{
    public InkGenerator ink;
    public GameObject[] bubbles;
    public bool isOnce;
    public AudioSource _audioSource;
    public void DrawingMode(bool isOn)
    {
        bubbles[0].SetActive(false);
        bubbles[1].SetActive(true);
        ink.isTouching = isOn;
        if (!isOnce)
        {
            isOnce = true;
            _audioSource.Play();
        }
    }
}
