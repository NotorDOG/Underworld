using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctions : MonoBehaviour
{
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
        
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
    #endif
    }
    public void Credit()
    {
    SceneManager.LoadScene("Credit");
    }
    public void Return()
    {
    SceneManager.LoadScene("MainMenu");
    }
    public void Continue()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
        }
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
