using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundSync : MonoBehaviour
{
    public GameObject musicobject;
    public bool follow;
    // Start is called before the first frame update
    void Start()
    {
        if (follow)
        DontDestroyOnLoad(musicobject);
    }

    // Update is called once per frame
    void Update()
    {
        var musicint = PlayerPrefs.GetFloat("mus_volume");
        musicobject.GetComponent<AudioSource>().volume = musicint;
        // FUCK
    }
}
