using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f; 
    public float lifeTime = 4f;
    public bool IsObstaclePunched = false;
    public PlayerCharacter playerCharacter;
    private AudioSource audioSource;
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

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (IsObstaclePunched == false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }else if (IsObstaclePunched == true)
        {
            GetComponent<Collider>().enabled = false;

            obstacle.SetActive(false);
            ObstaclePease1.SetActive(true);
            ObstaclePease2.SetActive(true);
            ObstaclePease3.SetActive(true);

            ObstaclePease1.transform.Translate(Vector3.forward * 30f * Time.deltaTime);
            ObstaclePease2.transform.Translate(Vector3.forward * 30f * Time.deltaTime);
            ObstaclePease3.transform.Translate(Vector3.forward * 30f * Time.deltaTime);

            ObstaclePease1.transform.Rotate(Vector3.back, 1000f * Time.deltaTime);
            ObstaclePease2.transform.Rotate(Vector3.back, 1000f * Time.deltaTime);
            ObstaclePease3.transform.Rotate(Vector3.back, 1000f * Time.deltaTime);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            IsObstaclePunched = true;
            audioSource.Play();
        }
        else if (other.CompareTag("Beer"))
        {
            Beer.CrushedBeers++;
            if (Beer.CrushedBeers == 2)
            {
                BadEnding();
            }
            Destroy(gameObject);
            
        }
        else if (other.CompareTag("Player"))
        {
            ObstacleSpawn.PuchedPlayer++;
            playerCharacter.DebuffPlayer();
            Destroy(gameObject);
        }  
    }
    void BadEnding()
    {
        ObstacleSpawn.BadEnd();
    }
}
