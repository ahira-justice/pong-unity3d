using UnityEngine;

public class HUD : MonoBehaviour {

    public GameObject pauseMenu;

    public void Pause(){
        MatchManager.paused = true;
        pauseMenu.transform.Find("Panel").gameObject.SetActive(true);
    }

    public void ShowServerChangeText(){
        transform.Find("Panel").transform.Find("ServerChange").gameObject.SetActive(true);
    }

    public void HideServerChangeText(){
        transform.Find("Panel").transform.Find("ServerChange").gameObject.SetActive(false);
    }

    public void HidePlayInfoText(){
        transform.Find("Panel").transform.Find("PlayInfo").gameObject.SetActive(false);
    }
}
