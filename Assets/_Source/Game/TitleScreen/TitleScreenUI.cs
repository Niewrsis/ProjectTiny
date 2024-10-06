using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject SettingsScreen;
    public GameObject TheBackgroundImage;
    public GameObject SoundVolumeGameObj;
    public GameObject MusicVolumeGameObj;


    private UIEffect BackgroundsEffect;
    private Slider SoundVolumeSlider;
    private Slider MusicVolumeSlider;

    public void StartGame() 
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("please know that TitleScreenUI leads to SampleScene");
    }

    public void Settings()
    {
        SettingsToggled(true);
    }

    public void Exit()
    {
        // maybe add a pop up that'd ask if the user is sure about leaving the game.

        Application.Quit();
    }

    public void SettingsToggled(bool amISettings)
    {
        BackgroundsEffect = TheBackgroundImage.GetComponent<UIEffect>();
        SoundVolumeSlider = SoundVolumeGameObj.GetComponent<Slider>();
        MusicVolumeSlider = MusicVolumeGameObj.GetComponent<Slider>();
        if (amISettings)
        {
            TitleScreen.SetActive(false);
            SettingsScreen.SetActive(true);
            BackgroundsEffect.blurFactor = 1.0f;
        }
        else
        {
            TitleScreen.SetActive(true);
            SettingsScreen.SetActive(false);
            BackgroundsEffect.blurFactor = 0f;
        }
        PlayerPrefs.SetFloat("sfx_volume", SoundVolumeSlider.value);
        PlayerPrefs.SetFloat("mus_volume", MusicVolumeSlider.value);
        PlayerPrefs.Save();
        // TODO implement volume manager IN GAME.
    }
}
