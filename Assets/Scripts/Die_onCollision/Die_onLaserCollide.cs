using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_onLaserCollide : MonoBehaviour
{
    void Collision_Las()
    {
        Destroy(gameObject);
    }
}
