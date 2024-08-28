using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottle : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 4f;
    public bool IsObstaclePunched = false;
    public PlayerCharacter playerCharacter;
    
    private void Start()
    {
        Destroy(gameObject, lifeTime);

        if (playerCharacter == null)
        {
            playerCharacter = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        }
    }

    private void Update()
    {
        if (IsObstaclePunched == false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (IsObstaclePunched == true)
        {
            transform.Translate(Vector3.forward * 30f * Time.deltaTime);
            transform.Rotate(Vector3.back, 1000f * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            IsObstaclePunched = true;

        }
        else if (other.CompareTag("Beer"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            
            playerCharacter.BuffPlayer();
            Destroy(gameObject);
        }
    }
}
