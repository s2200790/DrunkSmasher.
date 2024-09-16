using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float minX = -5f; 
    public float maxX = 5f;
    bool IsPlayerInEffect = false;

    public AudioClip BuffAudioClip;
    public AudioClip DebuffAudioClip;
    private AudioSource audioSource;

    public Vector3 NormalScale = new Vector3(0.45f, 0.45f, 0.45f);
    public Vector3 DamagedScale = new Vector3(0.2f, 0.2f, 0.2f);

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.localScale = NormalScale;
    }
    private void Update()
    { 

        float moveInput = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
    public void DebuffPlayer()
    {
        if (IsPlayerInEffect == false)
        {
            audioSource.PlayOneShot(DebuffAudioClip, 0.7f);

            IsPlayerInEffect = true;
            transform.localScale = DamagedScale;
            moveSpeed = 5f;

            StartCoroutine(WaitToReturnPlayer());

        }
    }
    public void BuffPlayer()
    {
        if (IsPlayerInEffect == false)
        {
            audioSource.PlayOneShot(BuffAudioClip, 0.7f);
            IsPlayerInEffect = true;
            moveSpeed = 15f;
            StartCoroutine(WaitToReturnPlayer());
        }
    }
    private IEnumerator WaitToReturnPlayer()
    {
        yield return new WaitForSeconds(5f);

        moveSpeed = 10f;
        transform.localScale = NormalScale;
    }

}

