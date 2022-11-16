using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHand : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    private float time = 0f;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (_animator.GetFloat("Flex") < 1f)
        {
            if (time < timer)
            {
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
                _animator.SetFloat("Flex", 1f);
            }
        
            
        }
        else
        {
            if (time < timer)
            {
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
                _animator.SetFloat("Flex", 0);
            }
            
        }
        // if (_animator.GetFloat("Flex") < 1f)
        // {
        //     _animator.SetFloat("Flex", _animator.GetFloat("Flex") + Time.deltaTime * timer);
        // }
        // else
        // {
        //     _animator.SetFloat("Flex", 0f);
        // }
    }
}
