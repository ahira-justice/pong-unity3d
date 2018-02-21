using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaddleState{
    PLAYER, COMPUTER
}

public enum Difficulty{
    EASY, MEDIUM, HARD
}

public class PadddleController : MonoBehaviour
{

    public int paddleID;
    public GameObject ball;
    public PaddleState paddleState;

    public static Difficulty difficulty;
    public static Vector3[] paddlePositions = new Vector3[2];
    
    private float speed;
    private float moveHorizontal;
    private Vector3 movement;
    private Vector3 pointToReach;

    private void Awake() {
        paddlePositions[0] = new Vector3(-4f, 9f, 0f);
        paddlePositions[1] = new Vector3(4f, -9f, 0f);
    }

    private void Start() {
        if (paddleState == PaddleState.PLAYER)
            speed = 0.1f;
        else if (paddleState == PaddleState.COMPUTER){
            if (difficulty == Difficulty.EASY)
                speed = 0.1f;
            else if (difficulty == Difficulty.MEDIUM)
                speed = 0.15f;
            else if (difficulty == Difficulty.HARD)
                speed = 0.2f;
        }
    }

    private void Update() {
        if (MatchManager.serve) {
            if (BoardManager.boardBounds.Contains(transform.position)) {
                if (paddleState == PaddleState.PLAYER) {
                    moveHorizontal = Input.GetAxisRaw("Horizontal");
                }
                else if (paddleState == PaddleState.COMPUTER) {
                    pointToReach.y = transform.position.y;
                    pointToReach.x = ((pointToReach.y - ball.transform.position.y) / BallController.gradient) + ball.transform.position.x;
                    if (transform.position.x < pointToReach.x)
                        moveHorizontal = 1;
                    else if (transform.position.x > pointToReach.x)
                        moveHorizontal = -1;
                    else
                        moveHorizontal = 0;
                }
                movement = new Vector3(moveHorizontal, 0, 0);
                movement = movement * Time.timeScale * speed;
                transform.Translate(movement);
            }
            else if (!BoardManager.boardBounds.Contains(transform.position)) {
                transform.Translate(-(movement * 0.5f));
            }
        }
    }

    public void ResetPaddle() {
        transform.position = paddlePositions[paddleID-1];
    }
}