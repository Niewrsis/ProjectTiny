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
        SceneManager.LoadScene("TitleMenu");
    }
} 
