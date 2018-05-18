using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    public delegate void onDeSpawn();
    public static event onDeSpawn OnDeSpawn;

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

            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
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
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(whitecolor());

        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 transform.eulerAngles.z + adjustSplatterAngle);


            Instantiate(splatterPrefab, transform.position, newRot);

            if (OnDeSpawn != null) OnDeSpawn();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    IEnumerator whitecolor()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
