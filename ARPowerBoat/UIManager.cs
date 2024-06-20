using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class UIManager : MonoBehaviour
{

    public ARCameraManager cameraManager;
    public ARPlaneManager planeManager;
    public GameObject moveDeviceAnimation;
    public GameObject tapAnimation;
    public VideoNButtonsStatus menuScript;

    //public PlaceOnPlane placeOnPlane;
    //public ARPlacementInteractable arPlacement;
	
	public GameObject planePrefab;

    private bool showingTapToPlace;
    private bool showingMoveDevice;

    void Start() {
        moveDeviceAnimation.SetActive(true);
        tapAnimation.SetActive(false);
        showingTapToPlace = false;
        showingMoveDevice = true;
        planeManager.planePrefab = planePrefab;
    }

    void OnEnable() 
    {
        cameraManager.frameReceived += FrameChanged;
        //placeOnPlane.onPlacedObject += PlacedObject;
        //arPlacement.objectPlaced.AddListener(PlacedObject);
    }

    void OnDisable() 
    {
        cameraManager.frameReceived -= FrameChanged;
        //placeOnPlane.onPlacedObject -= PlacedObject;
        //arPlacement.objectPlaced.RemoveListener(PlacedObject);
    }

    void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (planeManager.trackables.count > 0 && showingMoveDevice && HasBigEnoughPlane())
        {
            moveDeviceAnimation.SetActive(false);
            tapAnimation.SetActive(true);

            showingTapToPlace = true;
            showingMoveDevice = false;
        }
    }

    bool HasBigEnoughPlane() {
        foreach (var plane in planeManager.trackables) {
            if (plane.size.x >= 0.1f && plane.size.y >= 0.1f) return true;
        }
        return false;
    }

    void HideAllPlanes() {
        foreach (var plane in planeManager.trackables) 
        {
            plane.gameObject.SetActive(false);
        }
		planeManager.planePrefab = null;
    }

    public void Reset() {
        Start();
    }

    public void PlacedObject(ARObjectPlacementEventArgs args) {
        if (showingTapToPlace) {
            tapAnimation.SetActive(false);
            showingTapToPlace = false;
            HideAllPlanes();
            if (menuScript != null) menuScript.Init();
        }
    }

    /*void PlacedObject(GameObject go) {
        if (showingTapToPlace) {
            tapAnimation.SetActive(false);
            showingTapToPlace = false;
            HideAllPlanes();
        }
    }*/

    /*void PlacedObject(ARPlacementInteractable ar, GameObject go) {
        if (showingTapToPlace) {
            tapAnimation.SetActive(false);
            showingTapToPlace = false;
            HideAllPlanes();
        }
    }*/
}