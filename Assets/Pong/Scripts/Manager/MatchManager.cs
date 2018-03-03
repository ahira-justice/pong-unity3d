using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {
    public static bool paused;
    public static bool serve;
    public static int server;

    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject ball;
    public Text Score1;
    public Text Score2;

    private void Awake(){
        paused = false;
        serve = false;
        server = Random.Range(1, 3);
    }

    private void Start(){
        PaddleController paddleController1 = paddle1.GetComponent<PaddleController>();
        PaddleController paddleController2 = paddle2.GetComponent<PaddleController>();

        if (GameControl.playerID == 1){
            paddleController1.paddleState = PaddleState.PLAYER;
            paddleController2.paddleState = PaddleState.COMPUTER;
        }
        else if(GameControl.playerID == 2){
            paddleController1.paddleState = PaddleState.COMPUTER;
            paddleController2.paddleState = PaddleState.PLAYER;
        }
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && !serve && !paused){
            BallController.collideSound.Play();
            serve = true;
        }    
    }
}
