using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : Singleton<DrawManager>
{
    //현재 잉크랑
    //달라붙어있는 잉크그림들을 분리해야할 듯
    public List<InkTracker> Inks;
    public int count = 0;
    public List<InkTracker> copyInks;
    public GameObject table;
    public GameObject crayon;
    public GameObject palette;
    public Transform originPos;
    private Quaternion originRot;
    public void SetOnTable()
    {
        palette.SetActive(true);
        table.SetActive(true);
        originRot = crayon.transform.rotation;
        StartCoroutine(waitSaveOriginPos());
    }
    IEnumerator waitSaveOriginPos()
    {
        yield return new WaitForSeconds(0.2f);
        originPos = this.originPos;
        crayon.transform.position = originPos.position;
        crayon.transform.localEulerAngles = new Vector3(63.362f, -84.411f, -51.997f);
    }
    public void ClearInks()
    {
        if (Inks.Count > 0)
        {
            foreach (var VARIABLE in Inks)
            {
                Destroy(VARIABLE.gameObject);
            }
        }
        
        Inks.Clear();

        count = 0;
    }
    
    public void SetOffInks()
    {
        foreach (var item in Inks)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void SetOnInks(Vector3 endPos)
    {
        foreach (var item in copyInks)
        {
            item.gameObject.SetActive(true);
            var offset = item.GetComponent<InkTracker>().pencilPos;
            item.transform.position = endPos - offset; 
           
            item.transform.position += item.GetComponent<InkTracker>().offset;
            item.GetComponent<LineRenderer>().sortingOrder = TextManager.Instance.count;
        }
        copyInks.Clear();
        Inks.Clear();
        TextManager.Instance.count++;
    }

    public void SpawnAirPlane()
    {
        palette.SetActive(false);
        foreach (var VARIABLE in Inks)
        {
            copyInks.Add(VARIABLE);
        }
       // copyInks = Inks; //얕은 복사개념 들어가야함
       
        TextManager.Instance.SpawnPaperAirplane("DRAW");
    }
    public InkGenerator brush;
    public GameObject supportBrush;
    public GameObject[] bubbles;
    public void InitBrushSetting()
    {
        brush.isTouching = false;
        supportBrush.GetComponent<SupportPencil>().isOnce = false;
        bubbles[0].SetActive(true);
        bubbles[1].SetActive(false);
    }
}
