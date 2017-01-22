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

    private bool _paused;

    public bool paused
    {
        get { return _paused; }
    }

    /// <summary>
    /// The menu to toggle
    /// </summary>
    public GameObject menu;

    // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.GetInt("load") == 1)
        {
            LoadSaveGame.loadSaveGame.Load();
        }
        else
        {
            scoreCPU = 0;
            scoreHMN = 0;
        }

        gameOn = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (!_paused)
        {
            HMN.text = "HMN Score: " + scoreHMN;
            CPU.text = "CPU Score: " + scoreCPU;

            if ((scoreCPU == 3 || scoreHMN == 3) && gameOn)
            {
                Invoke("EndGame", 1.5f);
                gameOn = false;
            }
        }
    }

    void EndGame()
    {
        GameObject.Find("Ball of Evil").SetActive(false);

        GameObject.Find("Paddle - HMN").GetComponent<PaddleController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
    }

    void PauseGame()
    {
        _paused = !menu.activeSelf;
        if (_paused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 0.0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
        }
        Debug.Log(_paused);
        _paused = !menu.activeSelf;
        menu.SetActive(_paused);
        Debug.Log(_paused);
        
    }
}
