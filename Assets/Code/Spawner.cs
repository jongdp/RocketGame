using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject UFOPrefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 2;

    /// <summary>
    /// Gives the next time interval of when an enemy should spawn
    /// </summary>
    public float NextSpawn = 0;

    /// <summary>
    /// Gives the next time interval of when an enemy should spawn
    /// </summary>
    public Vector3 randLoc;

    // Update is called once per frame
    void Update()
    {
        if (!GameOver.isGameOver() && Time.time >= NextSpawn)
        {
            var ufo = Instantiate(UFOPrefab, randomLocation(), Quaternion.identity);
            ufo.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-2);
            NextSpawn += SpawnInterval;
        }
        
    }

    public Vector3 randomLocation()
    {
        var val = Random.Range(-9,9);
        randLoc = new Vector3(val, 4.5f, 0);
        return randLoc;
    }

}
