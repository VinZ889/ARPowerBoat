using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlaceOnPlane : MonoBehaviour
{        
    public GameObject prefab;
	public ARRaycastManager raycastManager;
    [HideInInspector]
    public GameObject spawnedObject;

    public event Action onPlacedObject;
    //public event Action<GameObject> onPlacedObject;

    void Update()
    {
        if (Input.touchCount > 0) 
		{			
			List<ARRaycastHit> hits = new List<ARRaycastHit>();
			if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon) && !IsOverUI())
			{
				var hitPose = hits[0].pose;
				if (spawnedObject == null)
				{
					spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);
				}
				else
				{
					spawnedObject.transform.position = hitPose.position;
				}

                Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, spawnedObject.transform.position.y, Camera.main.transform.position.z);
                spawnedObject.transform.LookAt(targetPosition, Vector3.up);

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