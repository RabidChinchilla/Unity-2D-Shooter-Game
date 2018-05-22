using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public float damageTime = 3.0f;
    public int damage = 2;
    public string targetTag = "Player";
    float timeColliding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if(!IsInvoking("ResetDamage"))
            {
                //if the object is colliding with the player send a take damage message
                collision.gameObject.SendMessage("TakeDamage", damage);
                //after the damage has been taken disable the collider and the invoke the reset to put it back
                GetComponent<Collider2D>().enabled = false;
                Invoke("ResetDamage", 0.5f);
            }
        }
        /*
        if (collision.gameObject.tag == targetTag)
        {
            if (timeColliding < damageTime)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
                timeColliding = 0.0f;
            }
        }
        */
    }

    void ResetDamage()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
