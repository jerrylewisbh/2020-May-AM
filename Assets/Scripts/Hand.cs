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

    [SerializeField] [Tooltip("is keyboard and mouse interaction available?")]
    private bool keyBoardAndMouseEnabled = false;


    [SerializeField] private float throwForce = 10;

    [SerializeField] private float simHandMoveSpeed = 20;
    private GameObject selectedObject = null;

    private bool isGrabbing = false;

    private Vector3 originalPosition;
    private Vector3 originalRotation;

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
        originalPosition = transform.position;
        originalRotation = transform.rotation.eulerAngles;


        MoveSimHand();

        float gripValue = Input.GetAxis(gripButtonAxis);
        bool isMouseButtonPressed = false;

        if (Input.GetMouseButton(mouseButton))
        {
            isMouseButtonPressed = true;
        }

        if (Input.GetMouseButtonUp(mouseButton))
        {
            isMouseButtonPressed = false;
        }


        if ((gripValue > 0 && !keyBoardAndMouseEnabled) || isMouseButtonPressed)
        {
            animator.SetBool("GripPressed", true);
        }
        else
        {
            animator.SetBool("GripPressed", false);
        }

        if ((gripValue == 1 && !keyBoardAndMouseEnabled) || isMouseButtonPressed)
        {
            if (!isGrabbing)
            {
                Grab();
            }
        }

        if ((gripValue == 0 && !keyBoardAndMouseEnabled) || !isMouseButtonPressed)
        {
            if (isGrabbing)
            {
                Release();
            }
        }


        if (isGrabbing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interactible interactible = selectedObject.GetComponent<Interactible>();

                if (interactible != null)
                {
                    interactible.Interact();
                }
            }
        }
    }

    private void MoveSimHand()
    {
        if (keyBoardAndMouseEnabled)
        {
            if (Input.GetKey(KeyCode.I))
            {
                transform.Translate(Vector3.forward * simHandMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.K))
            {
                transform.Translate(Vector3.back * simHandMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.L))
            {
                transform.Translate(Vector3.right * simHandMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.J))
            {
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
            otherRigidbody.isKinematic = true;
            isGrabbing = true;

            selectedObject.GetComponent<GrabbableObject>().isBeingGrabbed = true;

        }
    }

    private void Release()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.parent = null;

            Rigidbody otherRigidbody = selectedObject.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = false;

            Vector3 velocity = (transform.position - originalPosition) / Time.deltaTime;
            Vector3 angularVelocity = (transform.rotation.eulerAngles - originalRotation) / Time.deltaTime;

            otherRigidbody.velocity = velocity * throwForce;
            otherRigidbody.angularVelocity = angularVelocity * throwForce;

            isGrabbing = false;
            selectedObject.GetComponent<GrabbableObject>().isBeingGrabbed = false;
            selectedObject = null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isGrabbing)
        {
            GrabbableObject grabbale = other.gameObject.GetComponent<GrabbableObject>();

            if (grabbale != null)
            {
                selectedObject = other.gameObject;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (!isGrabbing)
        {
            selectedObject = other.gameObject;
        }
    }
}