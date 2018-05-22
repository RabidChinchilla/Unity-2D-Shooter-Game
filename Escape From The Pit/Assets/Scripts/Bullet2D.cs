using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour {

    public float speed = 5.0f;
    public float destroyTime = 0.7f;

	// Use this for initialization
	void Start () {
        Invoke("Die", destroyTime);
	}

    //when invoked will remove the game object from instance of the game
    void Die()
    {
        Destroy(gameObject);
    }

    //when called will invoke the die function
    void OnDestroy()
    {
        CancelInvoke("Die");
    }

    // Update is called once per frame
    void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}
}
