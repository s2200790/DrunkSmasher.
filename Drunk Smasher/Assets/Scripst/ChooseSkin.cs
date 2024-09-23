using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChooseSkin : MonoBehaviour
{
    public void ChooseSkin1()
    {
        UpdateSkinNumberInPrefs(1);
    }

    public void ChooseSkin2()
    {
        UpdateSkinNumberInPrefs(2);
    }

    public void ChooseSkin3()
    {
        UpdateSkinNumberInPrefs(3);
    }

    private void UpdateSkinNumberInPrefs(int skinNumber)
    {
        PlayerPrefs.SetInt("SkinNumber", skinNumber);
        PlayerPrefs.Save();

        Debug.Log("SkinNumber " + skinNumber + " päivitetty PlayerPrefs:iin");
    }
}