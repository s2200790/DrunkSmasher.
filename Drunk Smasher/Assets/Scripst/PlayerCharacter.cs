using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float minX = -5f; 
    public float maxX = 5f;  

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}

