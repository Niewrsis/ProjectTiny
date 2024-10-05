using Game.PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveString", menuName = "Events/SaveString")]
public class SaveStringEvent : Event
{
    public string key;
    public string value;
    public override void Main(EventTrigger eventTrigger, Player player)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }
}