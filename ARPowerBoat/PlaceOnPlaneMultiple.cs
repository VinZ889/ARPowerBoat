using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class PlaceOnPlaneMultiple : MonoBehaviour
{        
    public GameObject prefab;
	public ARRaycastManager raycastManager;
	[HideInInspector]
    public List<GameObject> spawnedObjects = new List<GameObject>();

    public event Action onPlacedObject;

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
		{			
			List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon) && !IsOverUI()) {
                var hitPose = hits[0].pose;
                GameObject spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);

                Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, spawnedObject.transform.position.y, Camera.main.transform.position.z);
                spawnedObject.transform.LookAt(targetPosition, Vector3.up);

                spawnedObjects.Add(spawnedObject);

                if (onPlacedObject != null) onPlacedObject();
            }
        }        
    }
	
	public bool IsOverUI() {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0)
        {
            for (int i = 0; i<results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<CanvasRenderer>())
                {
                    return true;
                }
            }
        }
        return false;
    }
}