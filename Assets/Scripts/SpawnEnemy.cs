using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    int spawnMax = 5;
    int spawned = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(15f,20f);
            whereToSpawn = new Vector2 (randX, transform.position.y);
            //spawn 5 NPC's when the level starts. 
            if(spawned < spawnMax) {
                Instantiate(enemy,whereToSpawn,Quaternion.identity);
                spawned++;
            } 
        }
    }
}
