using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSystem : MonoBehaviour
{
    public GameObject SkinButton;
    public GameObject SkinMenu;
    void Start()
    {
        
    }
    public void OpenSkins()
    {
        SkinMenu.SetActive(true);
        SkinButton.SetActive(false);
    }
    public void CloseSkins()
    {
        SkinButton.SetActive(true);
        SkinMenu.SetActive(false);
    }

    void Update()
    {
        
    }
}
