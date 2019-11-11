
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship_Movement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float accelInput;
    float rotateInput;
    public float responsiveness;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        accelInput = Input.GetAxis("Vertical") * responsiveness * 1.5f;
        rotateInput = Input.GetAxis("Horizontal") * responsiveness;

        rigidbody.rotation -= rotateInput;
        rigidbody.velocity = Quaternion.Euler(0, 0, rigidbody.rotation) * new Vector2(accelInput, 0);


    }
}
