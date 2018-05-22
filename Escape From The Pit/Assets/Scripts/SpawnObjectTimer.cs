using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTimer : MonoBehaviour {

    public float spawnTime = 10.0f;

	// Use this for initialization
	void Start () {
        //spawn one at the start
        Invoke("DoSpawn", spawnTime);
	}
	
	
	void DoSpawn () {
        //spawn when the time reaches its limit
        SendMessage("Spawn");
        Invoke("DoSpawn", spawnTime);
	}
}
