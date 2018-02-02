using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    public static int server;
    public static bool serve;

    public GameObject ball;

    private void Awake(){
        serve = false;
        server = 2;
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && !serve){
            serve = true;
        }

        
    }
}
