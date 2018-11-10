using UnityEngine;

public class Controller : MonoBehaviour {
    public static int input;
    public static bool touch;

    public void Move(int value){
        input = value;
    }
}
