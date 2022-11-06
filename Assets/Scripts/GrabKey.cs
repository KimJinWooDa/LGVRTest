using System;
using UnityEngine;

public class GrabKey : MonoBehaviour
{
    public Transform rightHand;
    [SerializeField] private float radius = 0.5f;
    private int layer;
    private void Start()
    {
        layer = LayerMask.NameToLayer("Stencil1");
    }

    [SerializeField] private Collider[] checkBox;
    private void Update()
    {
        checkBox = Physics.OverlapSphere(rightHand.position, radius, 1 << layer);
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) && checkBox.Length > 0)
        {
            checkBox[0].gameObject.layer = 0;
        }
    }
}
