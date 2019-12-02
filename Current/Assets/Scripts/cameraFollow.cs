using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Transform ship;
    void Start()
    {
        ship = GameObject.Find("Ship").transform;
    }

    void Update()
    {
        Vector3 newPosition = ship.position;
        newPosition.z -= 10; // to avoid camera clipping
        gameObject.transform.position = newPosition;
    }
}
