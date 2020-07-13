using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrushTip : MonoBehaviour
{
    public Material currentMaterial;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            currentMaterial = other.GetComponent<MeshRenderer>().material;
            GetComponent<MeshRenderer>().material = currentMaterial;
        }
    }
}
