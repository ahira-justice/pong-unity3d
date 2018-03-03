using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;

    public void Resume(){
        MatchManager.paused = false;
        pauseMenu.transform.Find("Panel").gameObject.SetActive(false);
    }

    public void Retry(){
        SceneManager.LoadScene("Main");
    }

    public void Exit(){
        SceneManager.LoadScene("Start");
    }
}
