using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float minX = -5f; 
    public float maxX = 5f;
    public GameObject Player;
    public GameObject DamagedPlayer;
    bool IsPlayerInEffect = false;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player.SetActive(true);
        DamagedPlayer.SetActive(false);
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
            audioSource.Play();
            IsPlayerInEffect = true;
            Player.SetActive(false);
            DamagedPlayer.SetActive(true);
            moveSpeed = 5f;

            StartCoroutine(WaitToReturnPlayer());

        }
    }
    public void BuffPlayer()
    {
        if (IsPlayerInEffect == false)
        {
            IsPlayerInEffect = true;
            moveSpeed = 15f;
            StartCoroutine(WaitToReturnPlayer());
        }
    }
    private IEnumerator WaitToReturnPlayer()
    {
        yield return new WaitForSeconds(5f);

        moveSpeed = 10f;
        Player.SetActive(true);
        DamagedPlayer.SetActive(false);
        IsPlayerInEffect = false;
    }

}

