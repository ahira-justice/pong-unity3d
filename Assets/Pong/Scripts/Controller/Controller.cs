using UnityEngine;

public class Controller : MonoBehaviour {
    public static int input;
    public static bool touch = false;

    public void Move(int value){
        if (value != 0)
            touch = true;
        else if (value == 0)
            touch = false;
        input = value;
    }
}
