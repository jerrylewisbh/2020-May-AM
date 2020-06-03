using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed;

    void Awake()
    {
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
    }
}
