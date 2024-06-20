using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerboatpart : MonoBehaviour
{
    public GameObject wave;
    public GameObject wave1;

    
    public void ActivateWave()
    {
        wave.SetActive(true);
        wave1.SetActive(true);
    }

    public void UnactivateWave()
    {
        wave1.SetActive(false);
        wave.SetActive(false);
    }
}
