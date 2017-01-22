using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    /// <summary>
    /// Button observed
    /// </summary>
    public Button yourButton;

    /// <summary>
    /// Gets the button and adds a listener to it
    /// </summary>
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    /// <summary>
    /// Restart Game on click
    /// </summary>
    void TaskOnClick()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("3D Pong");

    }
}
