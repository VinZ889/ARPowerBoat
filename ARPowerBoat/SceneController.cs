using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Cover;
    public RectTransform Nav;
    //public RectTransform Ins;
    public RectTransform select;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        Cover.SetActive(true);
        LeanTween.moveX(Nav, -1080, 0f);
        //LeanTween.moveX(Ins, -1080, 0f);
        LeanTween.moveX(select, -1080, 0f);
    }

    public void Startup()
    {
        Cover.SetActive(false);
        LeanTween.moveX(Nav, 0, 0.5f);
        //LeanTween.moveX(Ins, 0, 0.5f);
        LeanTween.delayedCall(5f, OnSelection);
    }

    public void OnSelection()
    {
        LeanTween.moveX(Nav, 1080, 0.5f);
        //LeanTween.moveX(Ins, 1080, 0.5f);
        LeanTween.moveX(select, 0, 0.5f);
    }

    public void firstAR()
    {
        SceneManager.LoadScene(1);
    }

    public void secAR()
    {
        SceneManager.LoadScene(2);
    }
}
