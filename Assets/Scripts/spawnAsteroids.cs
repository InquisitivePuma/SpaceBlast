using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{
    GameObject post;
    GameObject bounder;
    public GameObject asteroid;
    void Start()
    {
        post = GameObject.Find("CamPostTopRight");
        bounder = GameObject.Find("SpawnBounder");
        Invoke("spawnAsteroid", 1);
    }

    
    void spawnAsteroid()
    {
        Vector2 origin = gameObject.transform.position;
        Vector2 max = bounder.transform.position;
        Vector2 min = post.transform.position;
        // normalise by subtracting origin, making all calculations symetrical around 0,0
        max -= origin;
        min -= origin;
        Vector2 range = max - min;
        Vector3 spawnLocation;
        spawnLocation.x = dualRangeRandom(max.x, min.x, range.x);
        spawnLocation.y = dualRangeRandom(max.y, min.y, range.y);
        spawnLocation.z = 0;
        Instantiate(asteroid, spawnLocation, new Quaternion());
        Invoke("spawnAsteroid", 1);
    }

    private float dualRangeRandom(float max, float min, float range)
    {
        float num = Random.Range(min, min + (2*range));
        if(num > max)
        {
            num = range - num;
        }
        return num;
    }
}
