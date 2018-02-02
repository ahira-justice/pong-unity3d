using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaddleState{
    PLAYER, COMPUTER
}

public class PadddleController : MonoBehaviour
{

    public int paddleID;
    public PaddleState paddleState;

    public GameObject ball;

    public static Vector3[] paddlePositions = new Vector3[2];

    private float speed;
    private Vector3 movement;
    private Vector3 pointToReach;
    private float moveHorizontal;

    private void Awake() {
        paddlePositions[0] = new Vector3(-4f, 9f, 0f);
        paddlePositions[1] = new Vector3(4f, -9f, 0f);
    }

    private void Start() {
        if (paddleState == PaddleState.PLAYER)
            speed = 0.1f;
        else if (paddleState == PaddleState.COMPUTER)
            speed = 0.1f;
    }

    private void FixedUpdate() {
        if (MatchManager.serve) {
            if (BoardManager.boardBounds.Contains(transform.position)) {
                if (paddleState == PaddleState.PLAYER) {
                    moveHorizontal = Input.GetAxisRaw("Horizontal");
                }
                else if (paddleState == PaddleState.COMPUTER) {
                    Debug.Log (pointToReach.x);
                    pointToReach.y = transform.position.y;
                    pointToReach.x = (pointToReach.y - ball.transform.position.y + BallController.gradient * ball.transform.position.x) / BallController.gradient;
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