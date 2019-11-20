using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon_Fire : MonoBehaviour
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
        Invoke("Ready", 1 / fireRate);

        Instantiate(projectile, position.position, position.rotation);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && ready)
        {
            Fire();
        }
    }
}
