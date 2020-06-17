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

    public void Update()
    {
        float rightTriggerInput = Input.GetAxis("RightTrigger");
        Debug.Log(rightTriggerInput);
    }
}
