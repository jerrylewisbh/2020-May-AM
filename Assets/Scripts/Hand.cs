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
    private int mouseButton;
    
    [SerializeField]
    [Tooltip("is keyboard and mouse interaction available?")]
    private bool keyBoardAndMouseEnabled = false;

    [SerializeField] 
    private float simHandMoveSpeed = 20;
    
     

    private GameObject selectedObject = null;

    public void Awake()
    {
        
        animator = GetComponentInChildren<Animator>();

        if (handness == Handness.Right)
        {
            gripButtonAxis = "RightGrip";
            mouseButton = 1;
        }
        else
        {
            gripButtonAxis = "LeftGrip";
            mouseButton = 0;

        }
    }

    public void Update()
    {
        MoveSimHand();
        
        float gripValue = Input.GetAxis(gripButtonAxis);
        bool isMouseButtonPressed = false;

        if (Input.GetMouseButtonDown(mouseButton))
        {
            isMouseButtonPressed = true;
        }

        if (Input.GetMouseButtonUp(mouseButton))
        {
            isMouseButtonPressed = false;
        }
    
        

        if (gripValue > 0 || isMouseButtonPressed)
        {
            animator.SetBool("GripPressed", true);
        }
        else
        {
            animator.SetBool("GripPressed", false);
        }

        if (gripValue == 1 || isMouseButtonPressed)
        {
            Grab();
        }

        if (gripValue == 0 || !isMouseButtonPressed)
        {
            Release();
        }
    }

    private void MoveSimHand()
    {
        if (keyBoardAndMouseEnabled)
        {
            if(Input.GetKey(KeyCode.I)){
                transform.Translate(Vector3.forward * simHandMoveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.K)){
                transform.Translate(Vector3.back * simHandMoveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.L)){
                transform.Translate(Vector3.right * simHandMoveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.J)){
                transform.Translate(Vector3.left * simHandMoveSpeed * Time.deltaTime);
            }
        }

    }

    private void Grab()
    {
        if (selectedObject != null)
        {
            Debug.Log("Grab " + selectedObject.name);
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