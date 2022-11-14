using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform leftDoor;
    public Transform RightDoor;
    public GameObject[] keyPoints;
    private float openTime = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < keyPoints.Length; i++)
            {
                Destroy(keyPoints[i]);
            }
            StartCoroutine(Open());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KEY"))
        {
            Destroy(other.gameObject);
            for (int i = 0; i < keyPoints.Length; i++)
            {
                Destroy(keyPoints[i]);
            }
            StartCoroutine(Open());
        }
    }

    IEnumerator Open()
    {
        while (openTime > 0)
        {
            openTime -= Time.deltaTime;
            leftDoor.transform.position += Vector3.back * (Time.deltaTime * 0.6f);
            RightDoor.transform.position += Vector3.forward * (Time.deltaTime * 0.6f);
            yield return null;
        }
       
    }
}
