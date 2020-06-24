using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(LineRenderer))]
public class HighlightObject : MonoBehaviour
{
    
    public Color red = Color.red;
    public void Highlight()
    {
        
        GetComponent<Renderer>().material.color = red;
    }
    
}
