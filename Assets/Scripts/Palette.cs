using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : Singleton<Palette>
{
    public Transform hand;
    public Transform origin;
    public Material[] brushColor;
    public GameObject[] inkColor;
    
    private Vector3 OriginPosition;
    
    void Start()
    {
        OriginPosition = this.transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, hand.transform.position) > 1f)
        {
            this.transform.position = origin.position;
        }
    }
}
