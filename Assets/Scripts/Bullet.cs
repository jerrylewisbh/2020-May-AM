using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity == Vector3.zero)
        {
            Destroy(gameObject);
        }
    }


    public void OnCollisionEnter(Collision other)
    {
        if ( ! other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
