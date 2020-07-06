using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToInstantiate : MonoBehaviour
{
    private ARRaycastManager rayCastManager;

    [SerializeField] private GameObject prefabToInstantiate;

    private void Awake()
    {
        rayCastManager = GetComponent<ARRaycastManager>();
    }

    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        Vector2 currentTouchPosition;

        if (TryGetTouchPosition(out currentTouchPosition))
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            rayCastManager.Raycast(currentTouchPosition, hits, TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                Pose hitPose = hits[0].pose;
                GameObject newObject = Instantiate(prefabToInstantiate, hitPose.position, hitPose.rotation);
            }
        }
    }
}