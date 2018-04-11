using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float destroyTime = 0.7f;

	// Use this for initialization
	void Start () {
        Invoke("Die", destroyTime);
	}
	
	// Update is called once per frame
	void Die () {
        Destroy(gameObject);
	}
}
