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
    public Slider SoundVolumeSlider;
    public Slider MusicVolumeSlider;

    private void Start()
    {
        BackgroundsEffect = TheBackgroundImage.GetComponent<UIEffect>();
        SoundVolumeSlider = SoundVolumeGameObj.GetComponent<Slider>();
        MusicVolumeSlider = MusicVolumeGameObj.GetComponent<Slider>();

        MusicVolumeSlider.value = PlayerPrefs.GetFloat("mus_volume");
        SoundVolumeSlider.value = PlayerPrefs.GetFloat("sfx_volume");
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Scene1");
        Debug.Log("idk where the hell is tutorial so i teleport you to first level");
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

    public void ChangeVolume(bool music)
    {
        if (music) 
        { 
            PlayerPrefs.SetFloat("mus_volume", MusicVolumeSlider.value);
        } else 
        { 
            PlayerPrefs.SetFloat("sfx_volume", SoundVolumeSlider.value);
        }

        PlayerPrefs.Save();
    }
}
