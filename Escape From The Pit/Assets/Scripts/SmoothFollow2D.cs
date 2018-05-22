using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float smoothing = 80.0f;


    void FixedUpdate ()
    {
        //have the enemy rotate at a smooth speed
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));

        
    }
}
