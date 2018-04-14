using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

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
