using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit2D : MonoBehaviour {

    public int damage = 1;
    public string damageTag = "";
    void OnTriggerEnter2D(Collider2D other)
    {
        //compares the tag of the object that has collied with the bullet
        if (other.CompareTag(damageTag))
        {
            //if the tags match send the take damage message to the object and if it has a take damage     
            other.SendMessage("TakeDamage", damage);
        }
        //removes the bullet once it has collided with an object
        Destroy(gameObject);
    }
}
