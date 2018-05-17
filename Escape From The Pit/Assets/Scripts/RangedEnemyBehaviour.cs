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

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireSpeed = 0.0f;
    public int fireDelay = 0;

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
        if (Vector2.Distance(transform.position, player.position) > AttackDistance)
        {
            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget>().target = player;
        }
        else
        {
            if (fireDelay >= 100)
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
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

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
}
