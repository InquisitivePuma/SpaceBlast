using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload_OnShipDeath : MonoBehaviour
{
    void Collision_Ast()
    {
        if (enabled)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
