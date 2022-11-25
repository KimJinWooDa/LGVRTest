using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
   private ParticleSystem ps;
   public AudioSource _AudioSource;
      
   private void Awake()
   {
      _AudioSource = GetComponent<AudioSource>();
      ps = GetComponent<ParticleSystem>();
   }

   private void OnEnable()
   {
      _AudioSource.Play();
      ps.Play();
   }
}
