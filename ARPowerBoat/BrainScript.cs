using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainScript : MonoBehaviour
{
    public Animator animator;
    public List<GameObject> textPanels;
    bool showing = false;

    private void Start() {
        ShowTextPanels(false);
    }

    public void Explode() {
        animator.SetTrigger("Explode");
        ShowTextPanels(false);
        showing = false;
    }

    public void Implode() {
        animator.SetTrigger("Implode");
        ShowTextPanels(false);
        showing = false;
    }

    public void ToggleInfo() {
        showing = !showing;
        ShowTextPanels(showing);
    }

    void ShowTextPanels(bool flag) {
        for (int i=0; i<textPanels.Count; i++) {
            textPanels[i].SetActive(flag);
        }
    }
}
