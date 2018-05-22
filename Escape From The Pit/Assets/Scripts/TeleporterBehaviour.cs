using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterBehaviour : MonoBehaviour {

    public int health = 10;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;

    public void TakeDamage(int damage)
    {
        //when the teleporter takes damage lower it's health
        health -= damage;

        if (health <= 0)
        {
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }

            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 transform.eulerAngles.z + adjustExplosionAngle);
            //when out of health destroy the object
            Instantiate(explosionPrefab, transform.position, newRot);
            Destroy(gameObject);
        }
    }
}
