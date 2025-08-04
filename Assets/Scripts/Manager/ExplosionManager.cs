using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    //Destroy the GameObject when is called
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
