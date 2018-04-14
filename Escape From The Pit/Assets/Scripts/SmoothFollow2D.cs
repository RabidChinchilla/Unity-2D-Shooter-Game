using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float smoothing = 80.0f;
   // public float xMinimum = 10f;
   // public float xMaximum = 10f;
   // public float yMinimum = 10f;
   // public float yMaximum = 10f;


    void FixedUpdate () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));

        //transform.position = new Vector3(
        // Mathf.Clamp(transform.position.x, xMinimum, xMaximum), 
        // Mathf.Clamp(transform.position.y, yMinimum, yMaximum), 
        // transform.position.z);
    }
}
