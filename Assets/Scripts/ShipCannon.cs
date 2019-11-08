using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon : MonoBehaviour
{
    bool isFiring;
    public float fireRate;
    public Object projectile;
    void Ready()
    {
        isFiring = false;
    }
    void Start()
    {
        Ready();
    }

    void Fire()
    {
        isFiring = true;
        Invoke("Ready", 1/fireRate);

        Instantiate(projectile);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !isFiring)
        {
            Fire();
        }
    }
}
