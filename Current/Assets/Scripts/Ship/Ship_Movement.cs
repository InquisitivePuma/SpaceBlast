
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship_Movement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float accelInput;
    float rotateInput;
    bool stutterReady = true;
    public float responsiveness;
    public float stutterCooldown;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0,0,90));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.GetButton("Stutter"))
        {
            Move();
        }
        else
        {
            Rotate();
            if (stutterReady)
            {
                rigidbody.velocity = new Vector3(0, 0, 0);
                stutterReady = false;
                Invoke("StutterReady", stutterCooldown);
            }
        }

    }

    void Move()
    {
        accelInput = Input.GetAxis("Vertical") * responsiveness * 1.5f;
        rotateInput = Input.GetAxis("Horizontal") * responsiveness;

        rigidbody.rotation -= rotateInput;
        rigidbody.velocity = Quaternion.Euler(0, 0, rigidbody.rotation) * new Vector2(accelInput, 0);
    }

    void Rotate()
    {
        rotateInput = Input.GetAxis("Horizontal") * responsiveness;
        rigidbody.rotation -= rotateInput;
    }

    void StutterReady()
    {
        stutterReady = true;
    }
}
