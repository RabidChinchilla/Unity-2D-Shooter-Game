using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int levelIndex)
    {
        //load a scene based on the index indicated in the unity editor
        SceneManager.LoadScene(levelIndex);
    }
}
