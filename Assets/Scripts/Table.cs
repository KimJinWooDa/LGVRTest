using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject[] bubbles;
    public GameObject crayon;
    private Vector3 originPos;

    private void Awake()
    {
        //originPos = crayon.transform.localPosition;
    }

    private void OnEnable()
    {
        //crayon.transform.localPosition = originPos;
        bubbles[0].SetActive(true);
        bubbles[1].SetActive(false);
    }
}