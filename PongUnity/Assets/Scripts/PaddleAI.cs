using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour {

    private GameObject BallOfEvil;
    private float movementSpeed;

	// Use this for initialization
	void Start ()
    {
        BallOfEvil = GameObject.Find("Ball of Evil");

        movementSpeed = 4.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float y = BallOfEvil.transform.position.y - transform.position.y;
        float z = BallOfEvil.transform.position.z - transform.position.z;

        Vector3 position = transform.position;

        Vector3 movement = new Vector3(0.0f, y, z);

        position = position + movement * Time.deltaTime * movementSpeed;

        if (position.y < 1.0f)
            position = new Vector3(transform.position.x, 1.0f, position.z);
        if (position.y > 5.0f)
            position = new Vector3(transform.position.x, 5.0f, position.z);
        if (position.z < -2.0f)
            position = new Vector3(transform.position.x, position.y, -2.0f);
        if (position.z > 2.0f)
            position = new Vector3(transform.position.x, position.y, 2.0f);

        transform.position = position;
    }
}
