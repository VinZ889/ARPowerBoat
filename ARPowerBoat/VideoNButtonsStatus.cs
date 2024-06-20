using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoNButtonsStatus : MonoBehaviour
{
    [Header("Video Status")]
    public GameObject vidStart;
    public GameObject vidStop;
    public CanvasGroup VideoP;
    public VideoPlayer video;

    [Header("Button Status")]
    public GameObject EButton;
    public GameObject lightBtn;
    public GameObject lightOffBtn;
    public GameObject IMButton;
    public GameObject Info;
    public GameObject infoText;
    public GameObject NextPrevBtn;
    public GameObject DifferentLText;

    [Header("List of Light Buttons")]
    public RectTransform SternL;
    public RectTransform StarPortL;
    public RectTransform PortL;
    public RectTransform BoardL;
    public RectTransform NightL;

    [Header("List of Texts")]
    public RectTransform SternText;
    public RectTransform StarPortText;
    public RectTransform PortText;
    public RectTransform BoardText;
    public RectTransform NightText;

    bool showing = false;
    private bool exploded = false;

    void Start()
    {
        Reset();
    }

    public void VideoClick()
    {
        video.Play();
        LeanTween.alphaCanvas(VideoP, 1, 0.5f); // VideoP.SetActive(true);
        vidStart.SetActive(false);
        vidStop.SetActive(true);
    }
    
    
    public void VideoOffClick()
    {
        video.Stop();
        LeanTween.alphaCanvas(VideoP, 0, 0.5f);//VideoP.SetActive(false);
        vidStart.SetActive(true);
        vidStop.SetActive(false);

    }

    public void Reset()
    {
        LeanTween.alphaCanvas(VideoP, 0, 0f); //VideoP.SetActive(false);
        vidStart.SetActive(false);
        vidStop.SetActive(false);
        EButton.SetActive(false);
        IMButton.SetActive(false);
        lightBtn.SetActive(false);
        lightOffBtn.SetActive(false);
        Info.SetActive(false);
        DifferentLText.SetActive(false);
        LeanTween.moveX(SternL, -130, 0f);//SternL.SetActive(false);
        LeanTween.moveX(StarPortL, -130, 0f);//StarPortL.SetActive(false);
        LeanTween.moveX(PortL, -130, 0f);//PortL.SetActive(false);
        LeanTween.moveX(BoardL, -130, 0f);//BoardL.SetActive(false);
        LeanTween.moveX(NightL, -130, 0f);//NightL.SetActive(false);*/
        ShowTextPanels(false);
        NextPrevBtn.SetActive(false);
        exploded = false;
    }

    public void Init()
    {
        vidStart.SetActive(true);
        vidStop.SetActive(false);
        EButton.SetActive(true);
        IMButton.SetActive(false);
        lightBtn.SetActive(true);
        Info.SetActive(true);
        NextPrevBtn.SetActive(true);
    }

    public void ExplodeOnClick()
    {
        FindObjectOfType<PowerBoatStatus>().Explode();
        EButton.SetActive(false);
        IMButton.SetActive(true);
        exploded = true;
    }

    public void ImplodeOnClick()
    {
        FindObjectOfType<PowerBoatStatus>().Implode();
        EButton.SetActive(true);
        IMButton.SetActive(false);
        exploded = false;
    }

    // turn on Light buttons and descriptions
    public void OnLights()
    {
        LeanTween.moveX(SternL, 20, 0.5f).setEaseInOutElastic();
        LeanTween.moveX(StarPortL, 200, 0.5f).setEaseInOutElastic();
        LeanTween.moveX(PortL, 690, 0.5f).setEaseInOutElastic();
        LeanTween.moveX(BoardL, 380, 0.5f).setEaseInOutElastic();
        LeanTween.moveX(NightL, 740, 0.5f).setEaseInOutElastic();//NightL.SetActive(true);*/// all change to LeanTween command
        lightOffBtn.SetActive(true);
        DifferentLText.SetActive(true);
        lightBtn.SetActive(false);
        vidStart.SetActive(false);
        EButton.SetActive(false);
        IMButton.SetActive(false);
        Info.SetActive(false);
        NextPrevBtn.SetActive(false);
        LeanTween.moveY(SternText, -130, 0.5f);
        LeanTween.moveY(StarPortText, -130, 0.5f);
        LeanTween.moveY(BoardText, -130, 0.5f);
        LeanTween.moveY(PortText, -130, 0.5f);
        LeanTween.moveY(NightText, -130, 0.5f);
    }

    // turn off Light buttons and descriptions
    public void OffLights()
    {
        LeanTween.moveX(SternL, -130, 0.5f);
        LeanTween.moveX(StarPortL, -130, 0.5f);
        LeanTween.moveX(PortL, -130, 0.5f); 
        LeanTween.moveX(BoardL, -130, 0.5f); 
        LeanTween.moveX(NightL, -130, 0.5f);//NightL.SetActive(false);*/ // all change to LeanTween command
        lightOffBtn.SetActive(false);
        FindObjectOfType<PowerBoatStatus>().OffLight();
        DifferentLText.SetActive(false);
        lightBtn.SetActive(true);
        vidStart.SetActive(true);
        EButton.SetActive(true);
        Info.SetActive(true);
        NextPrevBtn.SetActive(true);
    }

    public void SternClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnStern();
        LeanTween.moveX(SternL, -130, 0.5f);
        LeanTween.moveY(SternText, 20, 0.5f);
        LeanTween.delayedCall(5f, OnLights); //Invoke("OnLights", 5);
    }

    public void StarPortClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnStarPort();
        LeanTween.moveX(StarPortL, -130, 0.5f); // all change to LeanTween command
        LeanTween.moveY(StarPortText, 20, 0.5f);
        LeanTween.delayedCall(5f, OnLights);
    }

    public void BoardClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnBoard();
        LeanTween.moveX(BoardL, -130, 0.5f);//BoardL.SetActive(false);
        LeanTween.moveY(BoardText, 20, 0.5f);
        LeanTween.delayedCall(5f, OnLights);
    }

    public void PortClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnPort();
        LeanTween.moveX(PortL, -130, 0.5f);
        LeanTween.moveY(PortText, 20, 0.5f);
        LeanTween.delayedCall(5f, OnLights);
    }

    public void NightLightClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnNight();
        LeanTween.moveX(NightL, -130, 0.5f);
        LeanTween.moveY(NightText, 20, 0.5f);
        LeanTween.delayedCall(5f, OnLights);
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

    public bool IsExploded()
    {
        return exploded;
    }
}
