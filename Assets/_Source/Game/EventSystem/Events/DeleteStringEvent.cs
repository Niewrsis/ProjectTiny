using Game.PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DeleteString", menuName = "Events/DeleteString")]
public class DeleteStringEvent : Event
{
    public string key;
    public override void Main(EventTrigger eventTrigger, Player player)
    {
        PlayerPrefs.DeleteKey(key);
        PlayerPrefs.Save();
    }
}