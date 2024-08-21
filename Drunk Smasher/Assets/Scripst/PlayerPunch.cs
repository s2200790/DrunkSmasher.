using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public float rotationSpeed = 200f; 
    private Quaternion originalRotation; 
    private Quaternion targetRotation; 
    private bool isRotating = false;
    private bool returnToOriginal = false; 

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void Update()
    {

        if (!isRotating && !returnToOriginal)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                StartRotation(150f); 
            }
            else if (Input.GetMouseButtonDown(1))
            {
                StartRotation(-150f); 
            }
        }
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
                returnToOriginal = true; 
                targetRotation = originalRotation; 
            }
        }

        if (returnToOriginal)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, originalRotation) < 0.1f)
            {
                returnToOriginal = false;
            }
        }
    }

    private void StartRotation(float angle)
    {
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, angle, 0f));
        isRotating = true;
    }
}
