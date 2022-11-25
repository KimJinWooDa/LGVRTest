using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardUser : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0f, this.transform.eulerAngles.y, 0f);
    }
}
