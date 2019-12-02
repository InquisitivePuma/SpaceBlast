using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderMessage : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        string name = gameObject.name;
        name = name.Substring(0, 3);
        other.transform.SendMessage("Collision_" + name, SendMessageOptions.DontRequireReceiver);

    }
}
