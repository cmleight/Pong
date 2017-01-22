using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float h = 0.5f * Input.GetAxis("Mouse X");
        float v = 0.5f * Input.GetAxis("Mouse Y");

        transform.Translate(0.0f, v, h);

        if (transform.position.y < 1.0f)
            transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        if (transform.position.y > 5.0f)
            transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
        if (transform.position.z < -2.0f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.0f);
        if (transform.position.z > 2.0f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 2.0f);
    }
}
