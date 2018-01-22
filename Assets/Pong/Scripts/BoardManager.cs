using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public static Bounds boardBounds;

    private Vector3 size;

    private void Start(){
        size = new Vector3(11f, 20f, 1f);
        boardBounds = new Bounds(transform.position, size);
    }
}
