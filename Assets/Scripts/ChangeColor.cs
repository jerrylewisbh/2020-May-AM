using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : Interactible
{
    public override void Interact()
    {
        float randomR = Random.Range(0f, 1f);
        float randomG = Random.Range(0f, 1f);
        float randomB = Random.Range(0f, 1f);

        GetComponent<Renderer>().material.color = new Color(randomR, randomG, randomB);
        
    }
}
