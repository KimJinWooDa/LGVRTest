using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AssertTest : MonoBehaviour
{
    public GameObject testAssert;

    private void Start()
    {
        Assert.IsNotNull(testAssert);
    }
}
