using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    //used in the despawing for the spawners so they lower the spawn count
    public delegate void onDeSpawn();
    public static event onDeSpawn OnDeSpawn;

    public int health = 10;
    public int damage = 2;
    public GameObject splatterPrefab;
    public float adjustSplatterAngle = 0.0f;
    public int soundDelay = 0;
    private Transform player;
    public float distance = 0.0f;

    void Start()
    {
        if (GameObject.FindWithTag("Player"))
        {
            //find the object with the player tag and move towards it
            player = GameObject.FindWithTag("Player").transform;

            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget>().target = player;

        }
    }
    private void Update()
    {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        //get the distance between the player and if it's 50 play the audio source on the object
        if (distance == 50)
        {
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
        //change the colour to red so to give the affect of a damage flash
        GetComponent<SpriteRenderer>().color = Color.red;
        //reset colour to white
        StartCoroutine(whitecolor());

        //take damage when the takedamage message is recieved
        //if the health gets to 0 destroy the game object
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
        //add velocity to the game object so it can move
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    IEnumerator whitecolor()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
