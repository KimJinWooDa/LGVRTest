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
    
  

    private void Update()
    {
        // if the pencil is touching and ink is not there, instantiate ink and get its comnponent
        if (isOn && isTouching && newInk == null)
        {
            newInk = Instantiate(inkPrefab);
            ink = newInk.GetComponent<InkTracker>();
            DrawManager.Instance.Inks.Add(ink);
            DrawManager.Instance.count++;
        }
        // if the pencil is touching and there is ink, the update the ink as per the pencil and paper position
        if (isOn && isTouching && newInk != null)
        {
            Vector3 pos = new Vector3(pencilTransform.position.x, pencilTransform.position.y, pencilTransform.position.z);
            ink.UpdateLineRenderer(pos + pencilOffset);
        }
        // if the pencil is not touching the paper,set the variable to null
        if (!isTouching)
            newInk = null;
    }
}
