using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkGenerator: Singleton<InkGenerator>
{
    public GameObject inkPrefab;

    [SerializeField] private Transform pencilTransform;

    [SerializeField] private Vector3 pencilOffset;

    [SerializeField] private GameObject palette;

    private InkTracker ink;
 
    [HideInInspector] public bool isTouching = false;

    private GameObject newInk = null;

    [HideInInspector] public bool isOn;


    private Vector3 originPos;
    private Vector3 laterPos;
    private Vector3 offset = Vector3.zero;

    private Material mat;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (inkPrefab == null) return;
        if (isOn && isTouching && newInk == null)
        {
            if (originPos != laterPos)
            {
                offset = laterPos - originPos;
                    originPos = laterPos;
            }
            newInk = Instantiate(inkPrefab);
           
            ink = newInk.GetComponent<InkTracker>();
            laterPos = ink.transform.position;
            ink.offset = offset;
            ink.pencilPos =  pencilTransform.position;
            DrawManager.Instance.Inks.Add(ink);
            DrawManager.Instance.count++;
        }
      
        if (isOn && isTouching && newInk != null)
        {
            var pos = pencilTransform.position;
            ink.UpdateLineRenderer(pos + pencilOffset);
        }

        if (!isTouching)
            newInk = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YELLOW"))
        {
            this.inkPrefab = Palette.Instance.inkColor[1];
            mat = Palette.Instance.brushColor[1];
            
        }
        else if (other.CompareTag("PINK"))
        {
            this.inkPrefab = Palette.Instance.inkColor[0];
            mat = Palette.Instance.brushColor[0];
        }
        else if (other.CompareTag("GREEN"))
        {
            this.inkPrefab = Palette.Instance.inkColor[2];
            mat = Palette.Instance.brushColor[2];
        }
        else if (other.CompareTag("BLUE"))
        {
            this.inkPrefab = Palette.Instance.inkColor[3];
            mat = Palette.Instance.brushColor[3];
        }
        else if (other.CompareTag("PURPLE"))
        {
            this.inkPrefab = Palette.Instance.inkColor[4];
            mat = Palette.Instance.brushColor[4];
        }

        GetComponent<Renderer>().material = mat;
    }
}
