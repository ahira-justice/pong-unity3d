﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {
    public static bool paused;
    public static bool serve;
    public static int server;
    public static int playerScore;
    public static int computerScore;

    public GameObject gameOver;
    public GameObject HUD;
    public GameObject ball;
    public GameObject paddle1;
    public GameObject paddle2;
    public Text Score1;
    public Text Score2;

    private bool playerWins;
    private bool computerWins;
    private HUD hud;
    private BallController ballController;
    private PaddleController paddleController1;
    private PaddleController paddleController2;

    private void Awake(){
        paused = false;
        serve = false;
        server = Random.Range(1, 3);
    }

    private void Start(){
        hud = HUD.GetComponent<HUD>();
        ballController = ball.GetComponent<BallController>();
        paddleController1 = paddle1.GetComponent<PaddleController>();
        paddleController2 = paddle2.GetComponent<PaddleController>();

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
        if (Input.GetKeyDown(KeyCode.Escape))
            hud.Pause();

        if (Input.GetKeyDown(KeyCode.Return) && !serve && !paused){
            BallController.collideSound.Play();
            serve = true;
        }                                               

        if (playerScore >= 11)
            playerWins = true;
        else if (computerScore >= 11)
            computerWins = true;

        if (playerWins || computerWins){
            gameOver.transform.Find("Panel").gameObject.SetActive(true);

            if (playerWins)
                gameOver.transform.Find("Panel").transform.Find("Info").GetComponent<Text>().text = "PLAYER WINS";
            else if (computerWins)
                gameOver.transform.Find("Panel").transform.Find("Info").GetComponent<Text>().text = "COMPUTER WINS";
        }

        if (serve == false){
            ballController.SetBall(server);

            if (GameControl.playerID == 1){
                Score1.text = "" + playerScore;
                Score2.text = "" + computerScore;
            }
            else if (GameControl.playerID == 2){
                Score1.text = "" + computerScore;
                Score2.text = "" + playerScore;
            }

            if (playerScore + computerScore != 0 && (playerScore + computerScore) % 5 == 0){
                if (server == 1){
                    server = 2;
                    ballController.SetBall(server);
                }
                else if (server == 2){
                    server = 1;
                    ballController.SetBall(server);
                }
            }
        }
    }
}
