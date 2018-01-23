using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum XDir{
    LEFT, RIGHT
}

public enum YDir{
    DOWN, UP
}


public class BallController : MonoBehaviour {

    [HideInInspector]
    public Vector3 ballPaddleOffset;
    public GameObject[] paddles;

    public float gradient;
    private static XDir xDir;
    private static YDir yDir;
    private Vector3 xDisplacement;
    private Vector3 yDisplacement;

    private void Start(){
        ballPaddleOffset = new Vector3(0f, 0.2f, 0f);
        xDisplacement = new Vector3(0.1f, 0f, 0f);
        yDisplacement = new Vector3(0f, 0.1f, 0f);
        gradient = 2f;
    }

    private void Update(){
        if (!MatchManager.serve)
            transform.position = paddles[MatchManager.server-1].transform.position - ballPaddleOffset;

        if ((transform.position.y < BoardManager.ballBounds.min.y) || (transform.position.y > BoardManager.ballBounds.max.y))
            MatchManager.serve = false;

        if (MatchManager.serve){
            if (xDir == XDir.LEFT && transform.position.x < BoardManager.ballBounds.min.x){
                    xDir = XDir.RIGHT;
            }
            else if (xDir == XDir.RIGHT && transform.position.x > BoardManager.ballBounds.max.x){
                    xDir = XDir.LEFT;
            }

            MoveBall();
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

    private void MoveBall(){
        if (xDir == XDir.LEFT)
            transform.position -= (xDisplacement / gradient * Time.timeScale);
        else if(xDir == XDir.RIGHT)
            transform.position += (xDisplacement / gradient * Time.timeScale);

        if (yDir == YDir.DOWN)
            transform.position -= (yDisplacement * Time.timeScale);
        else if (yDir == YDir.UP)
            transform.position += (yDisplacement * Time.timeScale);
    }
}
