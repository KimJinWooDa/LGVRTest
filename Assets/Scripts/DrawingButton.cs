using UnityEngine;


public class DrawingButton : MonoBehaviour
{
    public GameObject table;
    public GameObject[] images;
    private bool isOn = false;


    public void DownScale()
    {
        table.transform.localScale = Vector3.zero;
        
    }
    public void Switch()
    {
        isOn = !isOn;
        InkGenerator.Instance.isOn = isOn;
    }
    private void Update()
    {
        images[0].gameObject.SetActive(isOn);
        images[1].gameObject.SetActive(!isOn);
    }
}
