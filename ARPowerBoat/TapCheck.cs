using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheck : MonoBehaviour
{
    public LayerMask layerMask;
    public VideoNButtonsStatus script;
    private Powerboatpart selected;

    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && script.IsExploded())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.tag == "lever")
                {
                    Powerboatpart boatPart = hit.collider.gameObject.GetComponent<Powerboatpart>();
                    if (boatPart != null)
                    {
                        if (selected == null)
                        {
                            boatPart.ActivateWave();
                            selected = boatPart;
                        }
                        else if (selected != null && selected != boatPart)
                        {
                            boatPart.UnactivateWave();
                            selected = boatPart;
                        }
                    }
                }
                
                    
            }
        }
    }
}

