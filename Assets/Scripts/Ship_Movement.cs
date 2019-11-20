
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.A))
        {
            CheckBasicInput();
        } else if (stutterReady)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
            stutterReady = false;
            Invoke("StutterReady", stutterCooldown);
        }

    }

    void CheckBasicInput()
    {
        accelInput = Input.GetAxis("Vertical") * responsiveness * 1.5f;
        rotateInput = Input.GetAxis("Horizontal") * responsiveness;

        rigidbody.rotation -= rotateInput;
        rigidbody.velocity = Quaternion.Euler(0, 0, rigidbody.rotation) * new Vector2(accelInput, 0);
    }

    void StutterReady()
    {
        stutterReady = true;
    }
}
