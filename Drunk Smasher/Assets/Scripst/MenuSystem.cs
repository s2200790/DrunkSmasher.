using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public GameObject Controls;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenControls()
    {
        Controls.SetActive(true);
    }

    public void CloseControls()
    {
        Controls.SetActive(false);
    }
    public void QuitApplication()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
