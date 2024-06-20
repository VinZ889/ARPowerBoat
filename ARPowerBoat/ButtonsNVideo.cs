using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ButtonsNVideo : MonoBehaviour
{
    [Header("Video Status")]
    public GameObject vidStart;
    public GameObject vidStop;
    public GameObject VideoP;
    public VideoPlayer video;
    
    [Header("Button Status")]
    public GameObject EButton;
    public GameObject lightBtn;
    public GameObject lightOffBtn;
    public GameObject IMButton;
    public GameObject Info;
    public GameObject infoText;
    public GameObject NextBtn;
    public GameObject PrevBtn;

    [Header("List of Light Buttons")]
    public GameObject SternL;
    public GameObject StarPortL;
    public GameObject PortL;
    public GameObject BoardL;
    public GameObject NightL;

    bool showing = false;
    void Start()
    {
        Reset();
    }

    public void VideoClick()
    {
        video.Play();
        VideoP.SetActive(true);
        vidStart.SetActive(false);
        vidStop.SetActive(true);
    }


    public void VideoOffClick()
    {
        video.Stop();
        VideoP.SetActive(false);
        vidStart.SetActive(true);
        vidStop.SetActive(false);

    }

    public void Reset()
    {
        VideoP.SetActive(false);
        vidStart.SetActive(false);
        vidStop.SetActive(false);
        EButton.SetActive(false);
        IMButton.SetActive(false);
        lightBtn.SetActive(false);
        lightOffBtn.SetActive(false);
        Info.SetActive(false);
        SternL.SetActive(false);
        StarPortL.SetActive(false);
        PortL.SetActive(false);
        BoardL.SetActive(false);
        NightL.SetActive(false);
        ShowTextPanels(false);
        NextBtn.SetActive(false);
        PrevBtn.SetActive(false);
    }

    public void Init()
    {
        vidStart.SetActive(true);
        vidStop.SetActive(false);
        EButton.SetActive(true);
        IMButton.SetActive(false);
        lightBtn.SetActive(true);
        Info.SetActive(true);
        NextBtn.SetActive(true);
        PrevBtn.SetActive(true);
    }

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

    public void OnLights()
    {
        SternL.SetActive(true);
        StarPortL.SetActive(true);
        PortL.SetActive(true);
        BoardL.SetActive(true);
        NightL.SetActive(true);
        lightOffBtn.SetActive(true);
        lightBtn.SetActive(false);
        EButton.SetActive(false);
        IMButton.SetActive(false);
        Info.SetActive(false);
    }

    public void OffLights()
    {
        SternL.SetActive(false);
        StarPortL.SetActive(false);
        PortL.SetActive(false);
        BoardL.SetActive(false);
        NightL.SetActive(false);
        lightOffBtn.SetActive(false);
        FindObjectOfType<PowerBoatStatus>().OffLight();
        lightBtn.SetActive(true);
        EButton.SetActive(true);
        Info.SetActive(true);
    }

    public void SternClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnStern();
        SternL.SetActive(false);
        Invoke("OnLights", 5);
    }

    public void StarPortClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnStarPort();
        StarPortL.SetActive(false);
        Invoke("OnLights", 5);
    }

    public void BoardClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnBoard();
        BoardL.SetActive(false);
        Invoke("OnLights", 5);
    }

    public void PortClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnPort();
        PortL.SetActive(false);
        Invoke("OnLights", 5);
    }

    public void NightLightClick()
    {
        FindObjectOfType<PowerBoatStatus>().OnNight();
        NightL.SetActive(false);
        Invoke("OnLights", 5);
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
