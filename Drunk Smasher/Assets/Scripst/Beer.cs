using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject NormalBeer;
    public GameObject CrushedBeer;
    public static int CrushedBeers = 0;
    void Start()
    {
        NormalBeer.SetActive(true);
        CrushedBeer.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") )
        {
            audioSource.Play();
            NormalBeer.SetActive(false);
            CrushedBeer.SetActive(true);
        }
    }
}
