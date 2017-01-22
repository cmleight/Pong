using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{

    public void LoadByIndex(int sceneIndex)
    {
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(sceneIndex);
    }
}
