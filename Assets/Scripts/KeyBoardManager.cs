using UnityEngine;

public class KeyBoardManager : Singleton<KeyBoardManager>
{
    public void SetNormalUI()
    {
        TextManager.Instance.SetNormalUI(this.gameObject);
    }

    public void SetSuperUI()
    {
        TextManager.Instance.SetSuperChatUI(this.gameObject);
    }
    public void SetTable()
    {
        UIManager.Instance.isKeyBoardOn = true;
        UIManager.Instance.SetKeyBoard();
        DrawManager.Instance.SetOnTable();
    }
    public void ChangeInitProfile()
    {
        UIManager.Instance.isOnce = true;
    }

    public GameObject[] gos;
    public void SetOffGameObjects()
    {
        gos[0].SetActive(true);
        gos[1].SetActive(true);
    }
}
