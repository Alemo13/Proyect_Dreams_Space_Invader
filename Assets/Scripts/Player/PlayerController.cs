using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float moveSpeed = 5;
    private float horizontalMove;
    public float xRange = 8;

    

    void Update()
    {
        //Player In Bbounds
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        horizontalMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed * horizontalMove);

    }
}
