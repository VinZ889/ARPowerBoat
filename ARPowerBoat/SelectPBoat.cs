using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class SelectPBoat : MonoBehaviour
{
    public GameObject screen0;
    public GameObject screen1;

   public void NextScenceSelected()
    {
        screen0.SetActive(true);
        LeanTween.delayedCall(10f, NextScreen);        
    }

    public void NextScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void PrevScenceSelected()
    {
        screen1.SetActive(true);
        LeanTween.delayedCall(10f, PrevScreen);
    }

    public void PrevScreen()
    {
        SceneManager.LoadScene(1);
    }
}
