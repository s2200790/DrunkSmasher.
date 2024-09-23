using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SkinDataManager : MonoBehaviour
{

    public PlayerCharacter playerCharacter;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SkinNumber"))
        {
            ReadSkinFromPrefs();
        }
        else
        {
            CreateSkinInPrefs();
        }
    }


    private void CreateSkinInPrefs()
    {
        int defaultSkinNumber = 1;

        PlayerPrefs.SetInt("SkinNumber", defaultSkinNumber);
        PlayerPrefs.Save(); 

        Debug.Log("SkinNumber asetettu arvoon: " + defaultSkinNumber);

        ExecuteCase(defaultSkinNumber);
    }

    private void ReadSkinFromPrefs()
    {
        int skinNumber = PlayerPrefs.GetInt("SkinNumber");
        Debug.Log("PlayerPrefsist‰ luettu SkinNumber: " + skinNumber);
        ExecuteCase(skinNumber);
    }

    private void ExecuteCase(int skinNumber)
    {
        if (playerCharacter == null)
        {
            Debug.LogError("PlayerCharacter ei ole m‰‰ritelty!");
            return;
        }

        switch (skinNumber)
        {
            case 1:
                playerCharacter.ActiveSkin1();
                break;
            case 2:
                playerCharacter.ActiveSkin2();
                break;
            case 3:
                playerCharacter.ActiveSkin3();
                break;
            default:
                Debug.LogError("Tuntematon numero: " + skinNumber);
                break;
        }
    }


}