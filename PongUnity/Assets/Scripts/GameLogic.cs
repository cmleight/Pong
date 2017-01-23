using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public int scoreHMN;
    public int scoreCPU;

    public Text HMN;
    public Text CPU;

    public AudioSource EndMusic;
    public Rigidbody rigBall;
    public BallBehavior ball;
    public GameObject ballObj;

    public Camera zoomCam;

    private bool gameOn;
    //To pause ball
    private bool _gameState;
    private bool _paused;

    public bool gameState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }
    public bool paused
    {
        get { return _paused; }
    }

    /// <summary>
    /// The menu to toggle
    /// </summary>
    public GameObject menu;

    //To be Continued screen
    public GameObject tBContinued;

    // Use this for initialization
    void Start ()
    {
        if (LoadSaveGame.loadSaveGame.SaveExists() && PlayerPrefs.GetInt("load") == 1)
        {
            LoadSaveGame.loadSaveGame.Load();
        }
        else
        {
            scoreCPU = 0;
            scoreHMN = 0;
        }

        gameOn = true;
        _gameState = true;
        _paused = false;
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
                gameOn = false;
                Invoke("EndGame", 0.5f);
                
            }
        }
    }

    void EndGame()
    {
        GameObject.Find("Paddle - HMN").GetComponent<PaddleController>().enabled = false;
        EndMusic.Play();
        rigBall.velocity = Vector3.zero;
        rigBall.angularVelocity = Vector3.zero;
        rigBall.isKinematic = true;
        ball.velocity = 0;
        ball.initForce = Vector3.zero;
        Invoke("CamZoom", 9f);
        Invoke("EndBall", 15f);
        

    }

    void CamZoom()
    {
        zoomCam.transform.position= new Vector3 (ballObj.transform.position.x + 3, ballObj.transform.position.y, ballObj.transform.position.z);
        tBContinued.SetActive(true);
    }
    //Time delay before the Ball deactivates
    void EndBall()
    {
        GameObject.Find("Ball of Evil").SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
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
