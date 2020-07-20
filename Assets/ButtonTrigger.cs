using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    private bool isPressed = false;
    
    public void Press()
    {
        if (isPressed)
        {
            return;
        }
        
        SendMessageUpwards("PressEvent", SendMessageOptions.RequireReceiver);
        isPressed = true;
    }

    public void Release()
    {
        if (!isPressed)
        {
            return;
        }
        
        SendMessageUpwards("ReleaseEvent", SendMessageOptions.RequireReceiver);
        isPressed = false;
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (!isPressed)
            {
                Press();
            }
            else
            {
                Release();
            }
        }
    }
}
