using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        Debug.Log("Settings Opened");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
