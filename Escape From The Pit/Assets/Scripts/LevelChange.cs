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
            //when the player collides with the object trasport them to the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
