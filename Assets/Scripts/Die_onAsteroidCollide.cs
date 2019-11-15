using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_onAsteroidCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Collision_Ast()
    {
        Destroy(gameObject);
    }
}
