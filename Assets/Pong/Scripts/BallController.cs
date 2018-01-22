using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum XDir{
    LEFT, RIGHT
}

public enum YDir{
    UP, DOWN
}


public class BallController : MonoBehaviour {

    [HideInInspector]
    public Vector3 ballPaddleOffset;
    public GameObject[] paddles;

    public static XDir xDir;
    public static YDir yDir;

    private void Start(){
        ballPaddleOffset = new Vector3(0f, 0.2f, 0f);
    }

    private void Update(){
        if (!MatchManager.serve)
            transform.position = paddles[MatchManager.server-1].transform.position - ballPaddleOffset;

        if ((transform.position.y < BoardManager.boardBounds.min.y) || (transform.position.y > BoardManager.boardBounds.max.y))
            MatchManager.serve = false;

        if (MatchManager.serve){
            if (xDir == XDir.LEFT && transform.position.x < BoardManager.boardBounds.min.x){
                    xDir = XDir.RIGHT;
            }
            else if (xDir == XDir.RIGHT && transform.position.x > BoardManager.boardBounds.max.x){
                    xDir = XDir.LEFT;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Paddle")) {
            if (yDir == YDir.UP)
                yDir = YDir.DOWN;
            else if (yDir == YDir.DOWN)
                yDir = YDir.UP;
        }

    }
}
