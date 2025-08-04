using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    private float topBound = 6;
    private float bottomBound = -6;
    
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        } else if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }

    }
}
