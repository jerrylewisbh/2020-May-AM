using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Handness
{
    Right,
    Left,
}

public class Hand : MonoBehaviour
{
    public Handness handness;
    private Animator animator;
    private string gripButtonAxis;

    private GameObject selectedObject = null;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        if (handness == Handness.Right)
        {
            gripButtonAxis = "RightGrip";
        }
        else
        {
            gripButtonAxis = "LeftGrip";
        }
    }

    public void Update()
    {
        
        if(Input.GetKey(KeyCode.T))
        {
            transform.Translate( Vector3.forward * 20 * Time.deltaTime);
        }
        
        float gripValue = Input.GetAxis(gripButtonAxis);
        
        if (gripValue > 0)
        {
            animator.SetBool("GripPressed", true);
        }
        else
        {
            animator.SetBool("GripPressed", false);
        }

        if (gripValue == 1)
        {
            Grab();
        }

        if (gripValue == 0)
        {
            Release();
        }
        
    }

    private void Grab()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.parent = this.transform;
            Rigidbody otherRigidbody = selectedObject.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = false;
        }
    }

    private void Release()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.parent = null;
            
            Rigidbody otherRigidbody = selectedObject.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        selectedObject = other.gameObject;
    }

    private void OnCollisionExit(Collision other)
    {
        selectedObject = null;
    }
}
