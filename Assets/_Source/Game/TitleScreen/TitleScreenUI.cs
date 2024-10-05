using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("please know that TitleScreenUI leads to SampleScene");
    }

    public void Fart()
    {
        Debug.Log("Implement fart please");
    }

    public void Exit()
    {
        // maybe add a pop up that'd ask if the user is sure about leaving the game.

        Application.Quit();
    }

}
