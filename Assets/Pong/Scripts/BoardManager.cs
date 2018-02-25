using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    public static Bounds boardBounds;
    public static Bounds ballBounds;
    public static AudioSource collideSound;

    private Vector3 size;

    private void Start(){
        boardBounds = new Bounds(transform.position, new Vector3(11f, 20f, 1f));
        ballBounds = new Bounds(transform.position, new Vector3(13.3f, 20f, 1f));

        collideSound = GetComponent<AudioSource>();
    }
}
