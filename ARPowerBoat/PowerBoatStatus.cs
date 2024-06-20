using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoatStatus : MonoBehaviour
{
    public Animator anime;
    public GameObject stern;
    public GameObject starport;
    public GameObject board;
    public GameObject port;
    public GameObject night;

   
    public void Explode()
    {
        anime.SetTrigger("Explode");
    }

    public void Implode()
    {
        anime.SetTrigger("Implode");
    }

    public void OffLight()
    {
        stern.SetActive(false);
        starport.SetActive(false);
        board.SetActive(false);
        port.SetActive(false);
        night.SetActive(false);
    }

    public void OnStern()
    {
        stern.SetActive(true);
        starport.SetActive(false);
        board.SetActive(false);
        port.SetActive(false);
        night.SetActive(false);
    }

    public void OnStarPort()
    {
        stern.SetActive(false);
        starport.SetActive(true);
        board.SetActive(false);
        port.SetActive(false);
        night.SetActive(false);
    }

    public void OnBoard()
    {
        stern.SetActive(false);
        starport.SetActive(false);
        board.SetActive(true);
        port.SetActive(false);
        night.SetActive(false);
    }

    public void OnPort()
    {
        stern.SetActive(false);
        starport.SetActive(false);
        board.SetActive(false);
        port.SetActive(true);
        night.SetActive(false);
    }

    public void OnNight()
    {
        stern.SetActive(true);
        starport.SetActive(true);
        board.SetActive(true);
        port.SetActive(true);
        night.SetActive(true);
    }
}
