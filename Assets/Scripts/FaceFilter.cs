using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class FaceFilter : MonoBehaviour
{

    private ARFaceManager faceManager;

    public List<Material> faceFilters;
    private int currentIndex = 0;


    private void Awake()
    {
        faceManager = GetComponent<ARFaceManager>();
    }
    
    public void ChangeFilter()
    {
        currentIndex = currentIndex + 1;
        if (currentIndex > faceFilters.Count - 1 )
        {
            currentIndex = 0;
        }


        foreach (ARFace face in faceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = faceFilters[currentIndex];
        }

    }
    
}
