using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_onAsteroidCollide : MonoBehaviour
{
    public bool enabled;
    void Collision_Ast()
    {
        if (enabled)
        {
            Destroy(gameObject);
        }
    }
}
