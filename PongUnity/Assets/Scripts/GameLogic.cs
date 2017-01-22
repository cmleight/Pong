using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public int scoreHMN;
    public int scoreCPU;

    public Text HMN;
    public Text CPU;

    private bool gameOn;

	// Use this for initialization
	void Start ()
    {
        scoreCPU = 0;
        scoreHMN = 0;

        gameOn = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HMN.text = "HMN Score: " + scoreHMN;
        CPU.text = "CPU Score: " + scoreCPU;

		if ((scoreCPU == 3 || scoreHMN == 3) && gameOn)
        {
            Invoke("EndGame", 1.5f);
            gameOn = false;
        }
    }

    void EndGame()
    {
        GameObject.Find("Ball of Evil").SetActive(false);

        GameObject.Find("Paddle - HMN").GetComponent<PaddleController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
    }
}
