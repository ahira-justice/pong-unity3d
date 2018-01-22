using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    public static int server;
    public static bool serve;

    private void Start(){
        serve = false;
        server = 1;
    }
}
