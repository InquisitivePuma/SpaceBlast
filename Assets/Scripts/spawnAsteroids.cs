using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{
    GameObject post;
    GameObject bounder;
    public GameObject asteroid;
    public float spawnInterval;

    Vector3 origin;
    Vector3 max;
    Vector3 min;
    Vector3 range;
    Vector3 spawnLocation;

    void Start()
    {
        post = GameObject.Find("CamPostTopRight");
        bounder = GameObject.Find("SpawnBounder");
        Invoke("spawnAsteroid", spawnInterval);
    }

    
    void spawnAsteroid()
    {
        origin = gameObject.transform.position;
        max = bounder.transform.position;
        min = post.transform.position;
        // normalise by subtracting origin, making all calculations symetrical around 0,0
        max -= origin;
        min -= origin;
        range = max - min;
        if (Random.value < 0.5)
        {
            spawnLocation.x = DualRangeRandom(max.x, min.x, range.x);
            spawnLocation.y = Random.Range(max.y, -max.y);
        }
        else
        {
            spawnLocation.x = Random.Range(max.x, -max.x);
            spawnLocation.y = DualRangeRandom(max.y, min.y, range.y);
        }
        // add the origin back in to centre coordinates around current position
        spawnLocation += origin; 
        spawnLocation.z = 0;
        Instantiate(asteroid, spawnLocation, new Quaternion());

        Invoke("spawnAsteroid", spawnInterval);
    }

    private float DualRangeRandom(float max, float min, float range) // generates a random number betwen min and max or -min and -max
    {
        float num = Random.Range(min, min + (2*range));
        if(num > max)
        {
            num = range - num;
        }
        return num;
    }
}
