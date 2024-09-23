using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float minX = -5f; 
    public float maxX = 5f;

    public AudioClip BuffAudioClip;
    public AudioClip DebuffAudioClip;
    private AudioSource audioSource;

    public Vector3 NormalScale = new Vector3(0.45f, 0.45f, 0.45f);
    public Vector3 DamagedScale = new Vector3(0.2f, 0.2f, 0.2f);

    public GameObject Skin1;
    public GameObject Skin2;
     public GameObject Skin3;

    public bool isPlayerInEffect = false;
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
        if (isPlayerInEffect == false)
        {
            isPlayerInEffect = true;
            audioSource.PlayOneShot(DebuffAudioClip, 0.7f);
            transform.localScale = DamagedScale;
            moveSpeed = 5f;
            StartCoroutine(WaitToReturnPlayer());
        }
    }
    public void BuffPlayer()
    {
        if (isPlayerInEffect == false)
        {
            isPlayerInEffect = true;
            transform.localScale = NormalScale;
            audioSource.PlayOneShot(BuffAudioClip, 0.7f);
            moveSpeed = 15f;
            StartCoroutine(WaitToReturnPlayer());
        }
    }
    private IEnumerator WaitToReturnPlayer()
    {
        yield return new WaitForSeconds(4f);

        moveSpeed = 10f;
        transform.localScale = NormalScale;
        isPlayerInEffect = false;
    }
    public void ActiveSkin1()
    {
        Skin1.SetActive(true);
        Skin2.SetActive(false);
        Skin3.SetActive(false);
    }
    public void ActiveSkin2()
    {
        Skin1.SetActive(false);
        Skin2.SetActive(true);
        Skin3.SetActive(false);
    }
    public void ActiveSkin3()
    {
        Skin1.SetActive(false);
        Skin2.SetActive(false);
        Skin3.SetActive(true);
    }
}

