using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "PlaySound", menuName = "Events/PlaySound")]
public class PlaySoundEvent : Event
{
    public string soundClipName;
    public override void Main(EventTrigger eventTrigger, Player player)
    {
        // Logic to play the sound
        Debug.Log("Playing sound: " + soundClipName);
        Debug.Log("hey i'm actually not doing anything could you uhhhhh fill me with that code");
    }
}