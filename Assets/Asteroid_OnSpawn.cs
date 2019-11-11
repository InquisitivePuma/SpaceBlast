using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_OnSpawn : MonoBehaviour
{
    
    void Start()
    {
        GameObject topRight = GameObject.Find("CamPostTopRight");
        GameObject topLeft = GameObject.Find("CamPostTopLeft");
        GameObject botRight = GameObject.Find("CamPostBotRight");
        GameObject botLeft = GameObject.Find("CamPostBotLeft");

        double[] magnitude = new double[4];
        Vector3 toPost;

        Transform[] postTransforms = new Transform[4] {topLeft.transform,topRight.transform,botLeft.transform,botRight.transform };

        foreach (Transform t in postTransforms)
        {
            toPost = t.transform.position - transform.position;
            toPost.magnitude;
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
