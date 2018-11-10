using UnityEngine;

public enum PaddleState{
    PLAYER, COMPUTER
}

public class PaddleController : MonoBehaviour{
    public int paddleID;
    public GameObject ball;
    public PaddleState paddleState;

    public static float moveHorizontal;
    public static Vector3[] paddlePositions = new Vector3[2];
    
    private float speed;
    private Vector3 movement;

    private float m;
    private float x;
    private float y;
    private float x1;
    private float y1;

    private float[] pointToReach = new float[2];

    private void Awake() {
        paddlePositions[0] = new Vector3(-4f, 9f, 0f);
        paddlePositions[1] = new Vector3(4f, -9f, 0f);
    }

    private void Update() {
        if (MatchManager.serve) {
            if (BoardManager.boardBounds.Contains(transform.position)) {
                if (paddleState == PaddleState.PLAYER) {
                    speed = GameControl.playerSpeed;
                    moveHorizontal = Controller.input;
                }
                else if (paddleState == PaddleState.COMPUTER) {
                    speed = GameControl.computerSpeed;
                    if ((BallController.xDir == XDir.LEFT && BallController.yDir == YDir.UP) || (BallController.xDir == XDir.RIGHT && BallController.yDir == YDir.DOWN))
                        m = -BallController.gradient;
                    else if ((BallController.xDir == XDir.RIGHT && BallController.yDir == YDir.UP) || (BallController.xDir == XDir.LEFT && BallController.yDir == YDir.DOWN))
                        m = BallController.gradient;

                    x1 = ball.transform.position.x;
                    y1 = ball.transform.position.y;
                    y = transform.position.y;
                    x = (y - y1 + m * x1) / m;
                    pointToReach[0] = x;
                    pointToReach[1] = y;

                    if (pointToReach[0] - transform.position.x > 0.1f)
                        moveHorizontal = 1;
                    else if (pointToReach[0] - transform.position.x < -0.1f)
                        moveHorizontal = -1;
                    else
                        moveHorizontal = 0;
                }
                movement = new Vector3(moveHorizontal, 0, 0);
                movement = movement * Time.timeScale * speed;
                transform.Translate(movement);
            }
            else if (!BoardManager.boardBounds.Contains(transform.position)){
                transform.Translate(-(movement * 0.5f));
            }
        }
    }

    public void ResetPaddle(){
        transform.position = paddlePositions[paddleID-1];
    }
}