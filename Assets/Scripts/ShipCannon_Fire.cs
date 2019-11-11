using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon_Fire : MonoBehaviour
{
    bool isFiring;
    public float fireRate;
    public Object projectile;
    Transform position;

    void Ready()
    {
        isFiring = false;
    }
    void Start()
    {
        Ready();
        position = GetComponent<Transform>();
    }

    void Fire()
    {
        isFiring = true;
        Invoke("Ready", 1 / fireRate);

        Instantiate(projectile, position.position, position.rotation);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !isFiring)
        {
            Fire();
        }
    }
}
