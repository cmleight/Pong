using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour {

    public AudioSource ballToWall;
    public AudioSource ballToPadd;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Paddle")
            ballToPadd.Play();

        if (other.gameObject.tag == "Wall")
            ballToWall.Play();
    }
}
