using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty{
    EASY, MEDIUM, HARD
}

public class MatchManager : MonoBehaviour {
    public static int server;
    public static bool serve;

    public static Difficulty difficulty;

    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject ball;
    public Text Score1;
    public Text Score2;

    private void Awake(){
        serve = false;
        server = Random.Range(1, 3);
    }

    private void Start(){
        PadddleController paddleController1 = paddle1.GetComponent<PadddleController>();
        PadddleController paddleController2 = paddle2.GetComponent<PadddleController>();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && !serve){
            BallController.collideSound.Play();
            serve = true;
        }    
    }
}
