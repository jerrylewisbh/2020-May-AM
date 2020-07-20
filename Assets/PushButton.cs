using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    public UnityEvent Pressed;
    public UnityEvent Released;

    private Animator animator;
    private AudioSource source;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }

    public void PressEvent()
    {
        animator.SetBool("Pressed", true);
        Pressed?.Invoke(); // if(Pressed !=null){}
    }

    public void ReleaseEvent()
    {
        animator.SetBool("Pressed", false);
        Released?.Invoke();
    }
}