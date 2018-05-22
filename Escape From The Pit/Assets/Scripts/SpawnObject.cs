using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject objectPrefab;

    public int spawnCount = 0;
    public int spawnLimit = 15;
    void OnEnable()
    {
        GuardBehaviour.OnDeSpawn += DeSpawn;
    }

    void Spawn()
    {
        if (spawnCount < spawnLimit)
        {
            //when an enemy spawns increase the spawn count and place them at the location
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
        //when called lower the spawn count
        spawnCount--;
    }
}
