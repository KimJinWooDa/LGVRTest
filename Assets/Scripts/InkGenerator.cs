using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkGenerator: Singleton<InkGenerator>
{
    // variable to store ink prefab
    [SerializeField] private GameObject inkPrefab;
    // variable to store pencil transform
    [SerializeField] private Transform pencilTransform;
  
    // variable to store pencil offset
    [SerializeField] private Vector3 pencilOffset;
    
    // variable to store ink component
    private InkTracker ink;
    // variable to capture the touch
    public bool isTouching = false;
    // variableto store the newly created ink
    private GameObject newInk = null;

    public bool isOn;


    private Vector3 originPos;
    private Vector3 laterPos;
    private Vector3 offset = Vector3.zero;
    private void Update()
    {
        
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
            DrawManager.Instance.Inks.Add(ink);
            DrawManager.Instance.count++;
        }
      
        if (isOn && isTouching && newInk != null)
        {
            Vector3 pos = new Vector3(pencilTransform.position.x, pencilTransform.position.y, pencilTransform.position.z);
            ink.UpdateLineRenderer(pos + pencilOffset);
        }

        if (!isTouching)
            newInk = null;
    }
}
