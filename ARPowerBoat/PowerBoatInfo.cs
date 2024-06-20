using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoatInfo : MonoBehaviour
{
    public GameObject EButton;
    public GameObject IMButton;
    public GameObject Info;
    public GameObject infoText;

    bool showing = false;

    /*void Start()
    {
        ShowTextPanels(false);
    }*/

    public void ExplodeOnClick()
    {
        FindObjectOfType<PowerBoatStatus>().Explode();
        EButton.SetActive(false);
        IMButton.SetActive(true);
    }

    public void ImplodeOnClick()
    {
        FindObjectOfType<PowerBoatStatus>().Implode();
        EButton.SetActive(true);
        IMButton.SetActive(false);
    }

    public void Reset()
    {
        EButton.SetActive(false);
        IMButton.SetActive(false);
        Info.SetActive(false);
        ShowTextPanels(false);
    }

    public void InfoOnClick()
    {
        showing = !showing;
        ShowTextPanels(showing);
    }

    void ShowTextPanels(bool flag)
    {
        infoText.SetActive(flag);

    }
}
