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

    public GameObject obstacle;
    public GameObject ObstaclePease1;
    public GameObject ObstaclePease2;
    public GameObject ObstaclePease3;
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
            obstacle.SetActive(false);
            ObstaclePease1.SetActive(true);
            ObstaclePease2.SetActive(true);
            ObstaclePease3.SetActive(true);
            transform.Translate(Vector3.forward * 30f * Time.deltaTime);

            ObstaclePease1.transform.Rotate(Vector3.up, 1000f * Time.deltaTime);
            ObstaclePease2.transform.Rotate(Vector3.up, 1000f * Time.deltaTime);
            ObstaclePease3.transform.Rotate(Vector3.up, 1000f * Time.deltaTime);
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
