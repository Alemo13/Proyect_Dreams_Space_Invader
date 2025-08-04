using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InvadersController : MonoBehaviour
{
    public float moveSpeed;

    public GameObject[] prefabs;

    public int rows = 5;
    public int columns = 6;

    public float offsetHeight = 2.0f;
    public float offsetWidth = 2.0f;

    private Vector3 direction = Vector2.right;

    private bool hasAdvancedRow = false;

    private void Awake()
    {
        for(int row = 0; row < rows; row++)
        {
            float width = offsetWidth * (columns - 1);
            float height = offsetHeight * (rows - 1);
            Vector2 offset = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(offset.x, offset.y + (row * (offsetHeight/2)), 0.0f);
            for(int col = 0; col < columns; col++)
            {
                GameObject Invader = Instantiate(prefabs[row], transform);
                Vector3 position = rowPosition;
                position.x += col * offsetWidth;
                Invader.transform.localPosition = position;
            } 
        }
    }

    private void Start()
    {
        moveSpeed = GameManager.Instance.invaderSpeed;
    }

    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)            
                continue;
            if (!hasAdvancedRow)
            {
                if(direction == Vector3.right && invader.position.x >= (rightEdge.x -1.0f))
                {
                    AdvanceRow();
                    break;
                }
                else if(direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
                {
                    AdvanceRow();
                    break;
                }
            }
        }
        // Reset para el siguiente frame
        hasAdvancedRow = false;
    }

    private void AdvanceRow()
    {
        // Cambiar de dirección (izquierda ↔ derecha)
        direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;

        hasAdvancedRow = true;
    }
  
}
