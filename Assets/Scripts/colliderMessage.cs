using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderMessage : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        string[] name = gameObject.name.Split('('); 
        other.transform.SendMessage("Collision_" + name[0], SendMessageOptions.DontRequireReceiver);
        // Prefab objects are named 'objectname(x),' so splitting at the '(' allows us to grab just the base name of the object. 
        // This means that all copies of a prefab return the same name. 
    }
}
