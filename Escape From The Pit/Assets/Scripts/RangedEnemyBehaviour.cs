using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehaviour : MonoBehaviour {

    public delegate void onDeSpawn();
    public static event onDeSpawn OnDeSpawn;

    public int health = 20;
    public GameObject splatterPrefab;
    public float adjustSplatterAngle = 0.0f;
    public float AttackDistance = 2.0f;
    private Transform player;
    public int soundDelay = 0;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireSpeed = 0.0f;
    public int fireDelay = 0;
    public float distance = 0.0f;

    void Start()
    {
        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;

            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget>().target = player;
        }
    }

    void Update()
    {
        if (fireDelay >= 50)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            fireDelay = 0;
        }
        else
        {
            fireDelay = fireDelay + 1;
        }

        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distance == 50)
        {
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
        }

    }

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
