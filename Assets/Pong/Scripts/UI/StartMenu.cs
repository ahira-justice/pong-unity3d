using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    private GameObject optionsMenu;

    private void Awake(){
        optionsMenu = GameObject.FindWithTag("OptionsMenu");
    }

    public void Play(){
        SceneManager.LoadScene("Main");
    }

    public void Options(){
        optionsMenu.transform.Find("Panel").gameObject.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }
}
