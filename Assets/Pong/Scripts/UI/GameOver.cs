using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject gameOver;

    public void Retry(){
        MatchManager.playerScore = 0;
        MatchManager.computerScore = 0;
        SceneManager.LoadScene("Main");
    }

    public void Exit(){
        MatchManager.playerScore = 0;
        MatchManager.computerScore = 0;
        SceneManager.LoadScene("Start");
    }
}
