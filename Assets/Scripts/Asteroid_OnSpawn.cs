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
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        double[] magnitude = new double[4];
        Vector3 toPost;

        Transform[] postTransforms = new Transform[4] {topLeft.transform,topRight.transform,botLeft.transform,botRight.transform };

        int i = 0;
        foreach (Transform t in postTransforms) // finds the distance to each corner post
        {
            toPost = t.position - transform.position;
            magnitude[i] = toPost.magnitude;
            i++;
        }

        System.Array.Sort(magnitude, postTransforms); // sorts the array of corner posts by the distance to each one

        float maxAngle = Vector2.Angle(postTransforms[1].position - transform.position, postTransforms[2].position - transform.position); // calculates angle between second closest post, asteroid, and third closest post
        float randAngle = Random.Range(0f, maxAngle);
        Vector2 movementVector = Quaternion.Euler(0, 0, randAngle) * transform.position; // creates a randomly angled vector that passes through the asteroid and between the two posts 
        movementVector = movementVector.normalized * Random.Range(2f, 8f); // randomises the magnitude of the vector
        rigidbody.velocity = movementVector;
        

    }

    
}
