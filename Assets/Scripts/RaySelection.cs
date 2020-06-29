using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaySelection : MonoBehaviour
{
    [SerializeField] private float maxDistance = 100;

    private LineRenderer line;

    [SerializeField] private Color teleportableColor;

    [SerializeField] private Color notTeleportableColor;

    private bool canTeleport = false;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward * maxDistance);
        
        
       // Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);

        RaycastHit hitPoint;
        if (Physics.Raycast(transform.position, transform.forward, out hitPoint, maxDistance))
        {
            HighlightObject obj = hitPoint.collider.gameObject.GetComponent<HighlightObject>();

            if (obj != null)
            {
                obj.red = Color.magenta;
                obj.Highlight();
            }
        }
        
        if (hitPoint.collider != null)
        {
            if (hitPoint.collider.gameObject.layer == LayerMask.NameToLayer("Teleportable"))
            {
                line.GetComponent<Renderer>().material.color = teleportableColor;
                canTeleport = true;
            }
            else
            {
                line.GetComponent<Renderer>().material.color = notTeleportableColor;
                canTeleport = false;
            }
        }
        else
        {
            canTeleport = false;
            line.GetComponent<Renderer>().material.color = notTeleportableColor;
        }


        if (canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Vector3 newPos = new Vector3(hitPoint.point.x,  transform.parent.transform.position.y, hitPoint.point.z);
                transform.parent.localPosition = newPos;
            }
        }
        
        
    }
}