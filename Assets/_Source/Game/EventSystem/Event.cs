using UnityEngine;
using System.Collections.Generic;
using System;
using Game.PlayerSystem;

public class Event : ScriptableObject
{
    public bool eventIsBusy = false;

    // this... I don't think should be overriden. it basically safe rides the main function, and the main function will have whatever event was supposed to do.
    // FUCK. IT has to be virtual. but of course-  it will fuck up if you shove it in an async func
    public virtual void Execute(EventTrigger eventTrigger, Player player) 
    { 
        eventIsBusy = true;
        // TODO - decide if async events are needed. like it's 2am and fuck no I'm not coding all 'at again
        try 
        { 
            Main(eventTrigger, player); 
        } 
        catch (Exception e)
        {
            Debug.LogError(e);
        };
        eventIsBusy = false;
    }
    
    public virtual void Main(EventTrigger eventTrigger, Player player) 
    { 
        Debug.Log("Default, actionless event executed."); 
    }
    // TODO, Any Scripts that should be performed on a regular basis should be uh i had an idea here but now I have forgotten it.
}
public class EventAssigner
{
    private static readonly Dictionary<string, Type> eventTypesByName = new()
    {
        { nameof(TeleportGameObjectEvent), typeof(TeleportGameObjectEvent) },
        { nameof(ConditionalBranchEvent), typeof(ConditionalBranchEvent) },
        { nameof(PlaySoundEvent), typeof(PlaySoundEvent) },
        { nameof(CustomScriptEvent), typeof(CustomScriptEvent) }
    };

    private static readonly Dictionary<int, Type> eventTypesByID = new()
    {
        { (int)EventType.TeleportGameObjectEvent, typeof(TeleportGameObjectEvent) },
        { (int)EventType.ConditionalBranchEvent, typeof(ConditionalBranchEvent) },
        { (int)EventType.PlaySoundEvent, typeof(PlaySoundEvent) },
        { (int)EventType.CustomScriptEvent, typeof(CustomScriptEvent) }
    };

    public Event AssignByName(string name)
    {
        if (eventTypesByName.TryGetValue(name, out Type eventType))
        {
            return (Event)Activator.CreateInstance(eventType);
        }
        return ScriptableObject.CreateInstance<Event>(); // Default event if not found
    }

    public Event AssignByID(int id)
    {
        if (eventTypesByID.TryGetValue(id, out Type eventType))
        {
            return (Event)Activator.CreateInstance(eventType);
        }
        return ScriptableObject.CreateInstance<Event>(); // Default event if not found
    }

    public enum EventType
    {
        Event = 0,
        // dialogue event missing, please implement
        TeleportGameObjectEvent = 2,
        ConditionalBranchEvent = 3,
        PlaySoundEvent = 4,
        CustomScriptEvent = 5,
        // Manually add more if needed
        // If so, hopefully they are in the Events folder
    }
}

public class CustomScriptInjector : MonoBehaviour
{
    // TODO, check if this is even the right way to do it
    public MonoBehaviour script;
    public void Execute()
    {
        if (script != null)
        {
            // TODO, test it out and make sure it can be used (if ever used)
            string functionToRequest = "ExecuteDuringCustomScript";
            script.GetType().GetMethod(functionToRequest)?.Invoke(script, null);
        }
    }
}