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
    public void ClearInks()
    {
        if (Inks.Count <= 0)
        {
            UIManager.Instance.handPose.SetActive(false);
            count = 0;
            return;
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
            item.transform.localPosition = endPos; //이 부분만 약간 수정
        }
    }

    public void SpawnAirPlane()
    {
        copyInks = Inks;
        TextManager.Instance.SpawnPaperAirplane("DRAW");
    }
}
