﻿using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {
    public static bool paused;
    public static bool displayText;
    public static bool changingServer;
    public static bool computerServe;
    public static bool serve;
    public static int server;
    public static int playerScore;
    public static int computerScore;

    public GameObject gameOver;
    public GameObject HUD;
    public GameObject paddle1;
    public GameObject paddle2;
    public Text Score1;
    public Text Score2;

    private float displayStartTime;
    private float serveStartTime;
    private bool playerWins;
    private bool computerWins;
    private HUD hud;
    private PaddleController paddleController1;
    private PaddleController paddleController2;

    private void Awake(){
        paused = false;
        displayText = false;
        changingServer = false;
        computerServe = false;
        serve = false;
        server = GameControl.playerID;
    }

    private void Start(){
        hud = HUD.GetComponent<HUD>();

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

        if (server == GameControl.playerID){
            if (Input.GetKeyDown(KeyCode.Return) && !serve && !paused && !changingServer && !(playerWins || computerWins)){
                hud.HidePlayInfoText();
                BallController.collideSound.Play();
                serve = true;
            }
        }
        else if(server != GameControl.playerID){
            if (!computerServe && !serve && !paused && !changingServer && !(playerWins || computerWins)){
                serveStartTime = Time.time;
                computerServe = true;
            }
            if (!serve && computerServe && (Time.time - serveStartTime) >= 1.5f){
                BallController.collideSound.Play();
                serve = true;
                computerServe = false;
            }
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

        if (!serve){
            if (GameControl.playerID == 1){
                Score1.text = "" + playerScore;
                Score2.text = "" + computerScore;
            }
            else if (GameControl.playerID == 2){
                Score1.text = "" + computerScore;
                Score2.text = "" + playerScore;
            }
        }

        if (displayText){
            displayStartTime = Time.time;
            hud.ShowServerChangeText();
            displayText = false;
        }

        if (changingServer && (Time.time - displayStartTime) >= 2f){
            hud.HideServerChangeText();
            changingServer = false;
        }
    }

    private void OnEnable(){
        
    }

    public static void ChangeServer(){
        if (server == 1)
            server = 2;
        else if (server == 2)
            server = 1;
    }
}
