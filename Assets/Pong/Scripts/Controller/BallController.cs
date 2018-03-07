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
    public GameObject[] paddles;

    public static XDir xDir;
    public static YDir yDir;
    public static float gradient;
    public static AudioSource collideSound;

    private Vector2 contact;
    private Vector3 ballPaddleOffset;
    private Vector3 xDisplacement;
    private Vector3 yDisplacement;

    private void Start(){
        ballPaddleOffset = new Vector3(0f, 0.25f, 0f);
        xDisplacement = new Vector3(0.2f, 0f, 0f);
        yDisplacement = new Vector3(0f, 0.2f, 0f);

        gradient = 3f;

        collideSound = GetComponent<AudioSource>();

        SetBall(MatchManager.server);
    }

    private void Update(){
        if (GameControl.playerID == 1){
            if (transform.position.y < BoardManager.ballBounds.min.y)
                MatchManager.playerScore += 1;
            else if (transform.position.y > BoardManager.ballBounds.max.y)
                MatchManager.computerScore += 1;
        }
        else if (GameControl.playerID == 2){
            if (transform.position.y < BoardManager.ballBounds.min.y)
                MatchManager.computerScore += 1;
            else if (transform.position.y > BoardManager.ballBounds.max.y)
                MatchManager.playerScore += 1;
        }

        if ((transform.position.y < BoardManager.ballBounds.min.y) || (transform.position.y > BoardManager.ballBounds.max.y)){
            for (int i = 0; i < paddles.Length; i++)
                paddles[i].GetComponent<PaddleController>().ResetPaddle();

            gradient = 3f;
            MatchManager.serve = false;
        }

        if (MatchManager.serve && !MatchManager.paused){
            if (xDir == XDir.LEFT && transform.position.x < BoardManager.ballBounds.min.x){
                BoardManager.collideSound.Play();
                xDir = XDir.RIGHT;
            }
            else if (xDir == XDir.RIGHT && transform.position.x > BoardManager.ballBounds.max.x){
                BoardManager.collideSound.Play();
                xDir = XDir.LEFT;
            }

            MoveBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Paddle1") || other.gameObject.CompareTag("Paddle2")) {
            collideSound.Play();
            PaddleState paddleState = other.gameObject.GetComponent<PaddleController>().paddleState;

            if (paddleState == PaddleState.PLAYER)
                gradient = Random.Range(3, 6);
            else if (paddleState == PaddleState.COMPUTER)
            {
                if(GameControl.difficulty == Difficulty.EASY)
                    gradient = Random.Range(4, 6);
                else if (GameControl.difficulty == Difficulty.MEDIUM)
                    gradient = Random.Range(3, 6);
                else if (GameControl.difficulty == Difficulty.HARD)
                    gradient = Random.Range(2, 6);
            }

            
            contact = other.contacts[0].point;

            if (other.gameObject.CompareTag("Paddle1")){
                if ((contact.x - paddles[0].transform.position.x) < 0f)
                    xDir = XDir.LEFT;
                else if ((contact.x - paddles[0].transform.position.x) > 0f)
                    xDir = XDir.RIGHT;
            }

            else if (other.gameObject.CompareTag("Paddle2")){
                if ((contact.x - paddles[1].transform.position.x) < 0f)
                    xDir = XDir.LEFT;
                else if ((contact.x - paddles[1].transform.position.x) > 0f)
                    xDir = XDir.RIGHT;
            }

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

    public void SetBall(int server){
        if (server == 1){
            xDir = XDir.RIGHT;
            yDir = YDir.DOWN;
            transform.position = paddles[0].transform.position - ballPaddleOffset;
        }
        else if (server == 2){
            xDir = XDir.LEFT;
            yDir = YDir.UP;
            transform.position = paddles[1].transform.position + ballPaddleOffset;
        }
    }
}
