using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeatScreen : MonoBehaviour
{
    //BAREBONES.
    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToMenu()
    {
        Destroy(GameObject.Find("music player")); // hope that nobody renamed the music player in the first scene into something else
        SceneManager.LoadScene("TitleMenu");
    }
} 
