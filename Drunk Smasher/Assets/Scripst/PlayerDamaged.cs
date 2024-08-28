using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public float rotationSpeed = 200f;
    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool returnToOriginal = false;
    public float moveSpeed = 5f;
    public float minX = -5f;
    public float maxX = 5f;
    public GameObject Player;
    public GameObject DamagedPlayer;
    public Transform PlayerTransform;
    public Transform DamagedPlayerTransform;

    private void Start()
    {
        DamagedPlayerTransform = PlayerTransform;
        originalRotation = transform.rotation;
        StartWait();
    }

    private void Update()
    {

        if (!isRotating && !returnToOriginal)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartRotation(160f);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                StartRotation(-160f);
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
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }

    private void StartRotation(float angle)
    {
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, angle, 0f));
        isRotating = true;
    }
    void StartWait()
    {
        
        
    }
    
}
