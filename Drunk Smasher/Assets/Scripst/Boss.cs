using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float minX = -6f; 
    public float maxX = 6.5f; 
    public float initialSpeed = 2f; 
    public float speedIncreaseRate = 0.1f; 
    public float directionChangeProbability = 0.02f;

    private float currentSpeed;
    private int direction = 1; 

    private void Start()
    {
        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        currentSpeed += speedIncreaseRate * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(direction * currentSpeed * Time.deltaTime, 0f, 0f);

        if (newPosition.x <= minX || newPosition.x >= maxX)
        {
            direction *= -1;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); 
        }

        if (Random.value < directionChangeProbability)
        {
            direction *= -1;
        }

        transform.position = newPosition;
    }
}
