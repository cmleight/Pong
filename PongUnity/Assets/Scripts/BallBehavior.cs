﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    public GameLogic gameLogic;
    public Vector3 initialForce;

    private Rigidbody rigidBody;
    private float velocityBoost;

    public float velocity {
        get { return velocityBoost; }
        set { velocityBoost = value; }
    }
    public Vector3 initForce
    {
        get { return initialForce; }
        set { initialForce = value; }
    }
	// Use this for initialization
	void Start ()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();

        Invoke("BeginSet", 5.0f);

        velocityBoost = 1.05f;
    }

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<AudioSource>().Play();

        if (other.tag == "CPU Goal")
            gameLogic.scoreHMN++;

        if (other.tag == "HMN Goal")
            gameLogic.scoreCPU++;

        if (gameLogic.scoreCPU == 3 || gameLogic.scoreHMN == 3)
        {
            gameLogic.gameState = false;
            rigidBody.velocity = Vector3.zero;
            velocityBoost = 0;
            initialForce = Vector3.zero;
        }
            

        if (gameLogic.gameState)
        {
            Invoke("BallReset", 2.0f);
            Debug.Log(gameLogic.gameState);
        }
        else
        {
            Debug.Log(gameLogic.gameState);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        rigidBody.velocity *= velocityBoost;
    }

    void BallReset()
    {
        transform.position = new Vector3(0.0f, 3.0f, 0.0f);

        rigidBody.velocity = Vector3.zero;

        Invoke("BeginSet", 3.0f);
    }

    void BeginSet()
    {
        rigidBody.AddForce(initialForce, ForceMode.Impulse);
    }
}
