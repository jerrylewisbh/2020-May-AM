using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    public UnityEvent Pressed;
    public UnityEvent Released;

    [SerializeField] 
    private AudioClip pressSound;
    
    [SerializeField] 
    private AudioClip releaseSound;
    

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
        
        source.clip = pressSound;
        source.Play();
        
    }

    public void ReleaseEvent()
    {
        animator.SetBool("Pressed", false);
        Released?.Invoke();
        
        source.clip = releaseSound;
        source.Play();
    }
}