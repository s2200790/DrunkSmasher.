using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSystem : MonoBehaviour
{
    public GameObject SkinButton;
    public GameObject SkinMenu;
    public GameObject ReplayButton;
    void Start()
    {
        
    }
    public void OpenSkins()
    {
        ReplayButton.SetActive(false);
        SkinMenu.SetActive(true);
        SkinButton.SetActive(false);
    }
    public void CloseSkins()
    {
        ReplayButton.SetActive(true);
        SkinButton.SetActive(true);
        SkinMenu.SetActive(false);
    }
    public void Replay()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        
    }
}
