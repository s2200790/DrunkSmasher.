using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottle : MonoBehaviour
{
    public float speed = 10f; // Pullon putoamis nopeus
    public float lifeTime = 4f; // Milloin pullo tuhoutuu
    public bool IsObstaclePunched = false; // Onko pelaaja lyöny objektin
    public PlayerCharacter playerCharacter; // Pelaaja

    public GameObject obstacle; //Pullo
    public GameObject ObstaclePease1; // Pullon osa 1
    public GameObject ObstaclePease2; // Pullon osa 2
    public GameObject ObstaclePease3; // Pullon osa 3


    private void Start()
    {
        Destroy(gameObject, lifeTime); // Tuhotaan objekti kun aika on loppu

        if (playerCharacter == null) // testataan löytyykö PlayerCharacter koodi
        {
            playerCharacter = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        }
        
    }

    private void Update()
    {
        if (IsObstaclePunched == false) // Jos Pelaaja ei lyöny 
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime); // lentää alas
        }
        else if (IsObstaclePunched == true) // Jos pelaaja on lyöny
        {
            obstacle.SetActive(false); // Pullo otetaan pois
            // Pullon osat lisätään, jotka lentää pois
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
        if (other.CompareTag("Hammer")) // Jos objekti osuu Hammer objektiin
        {
            IsObstaclePunched = true; // Objekti on lyöty bool on true

        }
        else if (other.CompareTag("Beer")) // Jos objekti osuu olut objektiin 
        {
            Destroy(gameObject); // Objekti tuhoutuu
        }
        else if (other.CompareTag("Player")) // Jos objekti osuu pelaajaan 
        {
            playerCharacter.BuffPlayer(); // Palaajan nopeus kasvatetaan 
            Destroy(gameObject);
        }
    }
}
