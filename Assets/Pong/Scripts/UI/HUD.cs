using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public GameObject pauseMenu;

    public void Pause(){
        MatchManager.paused = true;
        pauseMenu.transform.Find("Panel").gameObject.SetActive(true);
    }
}
