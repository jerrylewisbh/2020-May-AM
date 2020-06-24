using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelection : MonoBehaviour
{

    [SerializeField]
    private float maxDistance = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);

        RaycastHit hitPoint;
        if (Physics.Raycast(transform.position, transform.forward, out hitPoint,maxDistance))
        {

            HighlightObject obj = hitPoint.collider.gameObject.GetComponent<HighlightObject>();

            if (obj != null)
            {
                obj.red = Color.magenta;
                obj.Highlight();
            }

        }
    }
}
