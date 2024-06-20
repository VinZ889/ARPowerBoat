using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class MenuScript : MonoBehaviour {
    public GameObject explodeButton;
    public GameObject implodeButton;
    public GameObject resetButton;
    public GameObject infoButton;

    //for reset
    public ARSession session;
    public UIManager uiManager;
    public ARPlacementInteractableSingleAnchor arPlacement;
    private bool exploded = false;

    void Start() {
        Reset();
    }

    public void ExplodeClick() {
        FindObjectOfType<BrainScript>().Explode();
        explodeButton.SetActive(false);
        implodeButton.SetActive(true);
        infoButton.SetActive(true);
        exploded = true;
    }

    public void ImplodeClick() {
        FindObjectOfType<BrainScript>().Implode();
        explodeButton.SetActive(true);
        implodeButton.SetActive(false);
        infoButton.SetActive(false);
        exploded = false;
    }

    public void ResetClick() {
        Reset();
        uiManager.Reset();
        arPlacement.ResetPlacementObject();
        session.Reset();
    }

    public void Reset() {
        explodeButton.SetActive(false);
        implodeButton.SetActive(false);
        resetButton.SetActive(false);
        infoButton.SetActive(false);
        exploded = false;
    }

    public void Init() {
        explodeButton.SetActive(true);
        implodeButton.SetActive(false);
        resetButton.SetActive(true);
    }

    public void InfoClick() {
        FindObjectOfType<BrainScript>().ToggleInfo();
    }

    public bool IsExploded() {
        return exploded;
    }
}
