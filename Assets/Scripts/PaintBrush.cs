using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : Interactible
{
    private TrailRenderer trail;
    private PaintBrushTip tip;
    
    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        tip = GetComponentInChildren<PaintBrushTip>();
        trail.emitting = false;
    }

    public override void Interact()
    {
        if (tip.currentMaterial != null)
        {
            trail.emitting = !trail.emitting;
            trail.GetComponent<TrailRenderer>().material = tip.currentMaterial;
        }
        
    }
}
