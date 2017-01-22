using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSceneOnClick : MonoBehaviour {

    public void saveState()
    {
        LoadSaveGame.loadSaveGame.Save();
    }
}
