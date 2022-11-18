using UnityEngine;

public class KeyBoardManager : MonoBehaviour
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
}
