using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPBowerSelected : MonoBehaviour
{
    public GameObject powerBt;
    public GameObject powerBt1;
    
    public void powerBoat1Selected()
    {
        powerBt.SetActive(true);
        powerBt1.SetActive(false);
    }

    public void powerBoat2Selected()
    {
        powerBt1.SetActive(true);
        powerBt.SetActive(false);
    }
}
