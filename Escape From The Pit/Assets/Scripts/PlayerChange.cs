using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour {

    public string targetTag = "Player";
    public GameObject newPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            Instantiate(newPlayer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
