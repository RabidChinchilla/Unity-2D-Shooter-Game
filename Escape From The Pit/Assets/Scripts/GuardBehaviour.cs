using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour {

    public int health = 10;
    public int damage = 2;
    public GameObject splatterPrefab;
    public float adjustSplatterAngle = 0.0f;

    private Transform player;

    void Start()
    {
        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;

            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget>().target = player;
        }
    }

    //void OnCollisionenter2D(Collision2D other)
    //{
   //     if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (other.gameObject.CompareTag("Player"))
    //        {
    //            other.gameObject.SendMessage("TakeDamage", damage);
    //        }
    //        GetComponent<Collider>().enabled = false;
    //        Invoke("Reset", 0.25f);
    //    }
    //}

    //void Reset()
    //{
    //    GetComponent<Collider>().enabled = true;
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 transform.eulerAngles.z + adjustSplatterAngle);

            Instantiate(splatterPrefab, transform.position, newRot);
            GetComponent<AddScore>().DoSendScore();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }
}
