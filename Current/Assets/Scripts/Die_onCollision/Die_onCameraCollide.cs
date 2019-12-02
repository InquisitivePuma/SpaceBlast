using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_onCameraCollide : MonoBehaviour
{
    void Collision_Cam()
    {
        Destroy(gameObject);
    }
}
