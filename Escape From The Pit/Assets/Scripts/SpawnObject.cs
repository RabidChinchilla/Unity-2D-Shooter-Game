using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject objectPrefab;

    public int spawnCount = 0;

    void OnEnable()
    {
        GuardBehaviour.OnDeSpawn += DeSpawn;
    }

    void Spawn()
    {
        if (spawnCount < 8)
        {
            spawnCount++;
            Instantiate(objectPrefab, transform.position, transform.rotation);
        }
    }

   // void Update()
   // {
    //    if(spawnCount > 15)
    //    {
            
    //    }
    //}

    void DeSpawn()
    {
        spawnCount--;
    }
}
