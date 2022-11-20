using System;
using Oculus.Interaction;
using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public GameObject[] setActiveBtns;
    private PokeInteractable _pokeInteractable;
    private void Awake()
    {
        _pokeInteractable = GetComponent<PokeInteractable>();
    }

    private void Update()
    {
        if (!TextManager.Instance.isChangeProfile) return;
        
        setActiveBtns[0].SetActive(UserInfoManager.Instance.userName == null);
        setActiveBtns[1].SetActive(UserInfoManager.Instance.userName != null);

        //_pokeInteractable.enabled = UserInfoManager.Instance.userName.Length > 0;
    }
}
