using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SendMessageUpwards("LeverChanged", other.gameObject.name, SendMessageOptions.DontRequireReceiver);
        Debug.Log("Collider: " + other.gameObject.name);
    }
}