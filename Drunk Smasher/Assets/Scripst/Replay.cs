using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
    void Update()
    {
        
    }
}
