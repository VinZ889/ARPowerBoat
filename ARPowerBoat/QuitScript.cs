using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public void OnQuitClick() {
        Application.Quit();
    }
	
	void OnApplicationPause(bool paused) {
		//if (paused) Application.Quit();
	}
}
