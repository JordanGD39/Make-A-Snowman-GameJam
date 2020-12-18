using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("I Quit");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void PausedGame()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
