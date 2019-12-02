using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_ShipCannon_Script : MonoBehaviour
{
    
    public int speed;
    void Start()
    {
        Rigidbody2D this_rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody2D ship_rigidbody = GameObject.Find("Ship").GetComponent <Rigidbody2D>();
        Vector2 vectorSpeed = new Vector2(speed, 0);
        Vector3 shipVelocity = ship_rigidbody.velocity;
        this_rigidbody.velocity = (Quaternion.Euler(0, 0, this_rigidbody.rotation) * vectorSpeed) + shipVelocity; // bullet velocity = (bullet speed * direction of ship) + velocity of ship
    }

    

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
