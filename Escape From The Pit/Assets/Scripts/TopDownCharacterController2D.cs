using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody2D rigidBody2D;

	void Start () {
        //apply a rigid body
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        //get input from WASD or controller sticks and use it as x and y input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //apply velocity based on input
        rigidBody2D.velocity = new Vector2(x, y) * speed;
        rigidBody2D.angularVelocity = 0.0f;
	}
}
