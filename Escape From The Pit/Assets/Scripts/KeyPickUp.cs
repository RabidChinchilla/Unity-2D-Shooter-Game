using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour {

    public GameObject Barrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            //when colliding with the player remove the barrier from the level that is attached to the key
            gameObject.SetActive(false);
            Destroy(Barrier);
        }
    }
}
