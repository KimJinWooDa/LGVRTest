using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTuberZoneBgm : MonoBehaviour
{
    public AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void StartBGM()
    {
        AS.Play();
    }
}
