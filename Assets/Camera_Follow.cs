using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    GameObject ship;
    Vector3 displacement = new Vector3(0,0,-10);
    private void Start()
    {
       ship = GameObject.Find("Ship");
    }
    void Update()
    {
        transform.position = ship.transform.position + displacement;
    }
}
