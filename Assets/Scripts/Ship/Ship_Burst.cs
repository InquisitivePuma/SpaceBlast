using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Burst : MonoBehaviour
{
    bool ready;
    public float fireRate;
    public float duration;
    public GameObject vfx;
    void Ready()
    {
        ready = true;
    }

    void Start()
    {
        Ready();
        transform.GetChild(0).GetComponent("Sprite Renderer");
    }

    void Burst()
    {
        ready = false;
        Invoke("Ready", 1f / fireRate);
        gameObject.GetComponent<Die_onAsteroidCollide>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        vfx.SetActive(true);
        Invoke("Unburst", duration);
    }

    void Unburst()
    {
        vfx.SetActive(false);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Die_onAsteroidCollide>().enabled = true;
    }

    void Update()
    {
        if (Input.GetButton("Burst") && ready)
        {
            Burst();
        }
    }
}
