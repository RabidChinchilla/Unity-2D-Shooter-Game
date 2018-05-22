using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {

    public string targetTag = "Player";
    public int heal = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            //if colliding with the player send the heal player message so the player regains health
            collision.gameObject.SendMessage("HealPlayer", heal);
            Destroy(gameObject);

        }
    }
}
