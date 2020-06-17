using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float turnSpeed = 50;
    private int score = 0;

    private Animator animator;

    public Text scoreText;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        Debug.Log("Awake was called");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start was called");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        controller.SimpleMove(transform.forward * speed * verticalInput * Time.deltaTime);

        if (verticalInput == 0)
        {
           
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);
        }
        
        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3(0, horizontalInput * turnSpeed * Time.deltaTime ,0);
        transform.Rotate(rotation);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {

            Collectible collectible = other.gameObject.GetComponent<Collectible>();
            score = score + collectible.points;
            Destroy(other.gameObject);

            scoreText.text = "Score: " + score.ToString();
            
            Debug.Log("current score: " + score);
            
        }

    }

     void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
    }

      void OnTriggerStay(Collider other)
     {
         Debug.Log("Trigger Stay");
     }
}
