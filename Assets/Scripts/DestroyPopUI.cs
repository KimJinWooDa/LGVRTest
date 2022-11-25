using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPopUI : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DEADZONE"))
        {
            Destroy(this.gameObject);
        }
    }
}
