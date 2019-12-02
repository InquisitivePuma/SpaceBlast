using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Cannon : MonoBehaviour
{
    bool ready;
    public float fireRate;
    public Object projectile;
    Transform position;

    void Ready()
    {
        ready = true;
    }
    void Start()
    {
        Ready();
        position = GetComponent<Transform>();
    }

    void Fire()
    {
        ready = false;
        Invoke("Ready", 1f / fireRate);

        Instantiate(projectile, position.position, position.rotation);
    }

    void Update()
    {
        if (Input.GetButton("Fire") && ready)
        {
            Fire();
        }
    }
}
