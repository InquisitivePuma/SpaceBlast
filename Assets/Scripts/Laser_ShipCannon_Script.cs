using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_ShipCannon_Script : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public int speed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 vectorSpeed = new Vector2(speed, 0);
        rigidbody.velocity = Quaternion.Euler(0, 0, rigidbody.rotation) * vectorSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("Laser_ShipCannon_Hit", SendMessageOptions.DontRequireReceiver);
        //Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
