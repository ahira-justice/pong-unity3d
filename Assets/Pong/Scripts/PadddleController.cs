using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaddleState{
    PLAYER, COMPUTER
}

public class PadddleController : MonoBehaviour {

    public int paddleID;
    public PaddleState paddleState;

    public GameObject ball;

    private float speed;
    private Vector3 movement;
    private float moveHorizontal;

    private void Start(){
        if (paddleState == PaddleState.PLAYER)
            speed = 0.1f;
        else if (paddleState == PaddleState.COMPUTER)
            speed = 0.1f;
    }

    private void Update(){
        if (MatchManager.serve){
            if (BoardManager.boardBounds.Contains(transform.position)){
                if (paddleState == PaddleState.PLAYER){
                    moveHorizontal = Input.GetAxisRaw("Horizontal");
                    movement = new Vector3(moveHorizontal, 0, 0);
                    movement = movement * speed * Time.timeScale;
                    transform.position += movement;
                }
            }
            else if (!BoardManager.boardBounds.Contains(transform.position)){
                transform.position -= movement;
            }
        }
    }
}
