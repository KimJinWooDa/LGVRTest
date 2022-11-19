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
    public Transform originPos;
    private Quaternion originRot;
    public void SetOnTable()
    {
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
            item.transform.position = endPos; //이 부분만 약간 수정
            item.transform.position += item.GetComponent<InkTracker>().offset;
        }
    }

    public void SpawnAirPlane()
    {
        copyInks = Inks; //얕은 복사개념 들어가야함
        TextManager.Instance.SpawnPaperAirplane("DRAW");
    }
}
