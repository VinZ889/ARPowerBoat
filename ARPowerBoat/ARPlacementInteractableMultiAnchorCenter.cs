using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.Interaction.Toolkit.AR
{
    public class ARPlacementInteractableMultiAnchorCenter : ARPlacementInteractable
    {
         readonly ARObjectPlacementEventArgs m_ObjectPlacementEventArgs = new ARObjectPlacementEventArgs();

        [HideInInspector]
        public List<GameObject> placementObjects = new List<GameObject> (); //changed
        public bool placeAtCenter;

        /// <inheritdoc />
        protected override void OnEndManipulation(TapGesture gesture)
        {
            //base.OnEndManipulation(gesture);

            if (gesture.isCanceled)
                return;

            if (xrOrigin == null)//(arSessionOrigin == null)
                return;

            //if (placementObject != null) return; //removed

            if (IsOverUI()) return;

            if (placeAtCenter) PlaceAtScreenCenter();
            else {
                if (TryGetPlacementPose(gesture, out var pose)) {
                    //var placementObject = PlaceObject(pose);
                    GameObject placementObject = PlaceObject(pose); //changed
                    placementObjects.Add(placementObject);

                    m_ObjectPlacementEventArgs.placementInteractable = this;
                    m_ObjectPlacementEventArgs.placementObject = placementObject;
                    OnObjectPlaced(m_ObjectPlacementEventArgs);
                }
            }
        }

        protected override GameObject PlaceObject(Pose pose) {
            var placementObject = Instantiate(placementPrefab, pose.position, pose.rotation);

            // Create anchor to track reference point and set it as the parent of placementObject.
            var anchor = new GameObject("PlacementAnchor").transform;
            anchor.position = pose.position;
            anchor.rotation = pose.rotation;
            placementObject.transform.parent = anchor;
            anchor.gameObject.AddComponent<ARAnchor>();

            // Use Trackables object in scene to use as parent
            var trackablesParent = xrOrigin != null
                ? xrOrigin.TrackablesParent
#pragma warning disable 618 // Calling deprecated property to help with backwards compatibility.
                : (arSessionOrigin != null ? arSessionOrigin.trackablesParent : null);
#pragma warning restore 618
            if (trackablesParent != null)
                anchor.parent = trackablesParent;

            return placementObject;
        }

        public bool IsOverUI() {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0) {
                for (int i = 0; i < results.Count; i++) {
                    if (results[i].gameObject.GetComponent<CanvasRenderer>()) {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ResetPlacementObject() { 
            placementObjects.Clear(); //changed
        }

        private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
        public ARRaycastManager raycastManager;
        public void PlaceAtScreenCenter() {
            if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon)) {
                var hit = hits[0];

                // Use hit pose and camera pose to check if hittest is from the
                // back of the plane, if it is, no need to create the anchor.
                if (Vector3.Dot(Camera.main.transform.position - hit.pose.position,
                        hit.pose.rotation * Vector3.up) < 0)
                    return;

                //can check plane size here

                GameObject placementObject = PlaceObject(hit.pose); //changed
                placementObjects.Add(placementObject); //added

                m_ObjectPlacementEventArgs.placementInteractable = this;
                m_ObjectPlacementEventArgs.placementObject = placementObject;
                OnObjectPlaced(m_ObjectPlacementEventArgs);
            }
        }

        public void RemovePlacementObject(GameObject obj) {
            placementObjects.Remove(obj);
            Destroy(obj);
        }
    }
}
