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
            //when colliding with the player create and deploy the new player model
            Instantiate(newPlayer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
