using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public string targetTag = "Player";

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == targetTag)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
