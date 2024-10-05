using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public List<EventTrigger> events = new List<EventTrigger>();

    public void AddEvent(EventTrigger e)
    {
        events.Add(e);
    }

    public void RemoveEvent(EventTrigger e)
    {
        events.Remove(e);
    }

    // TODO implement more commands to control the EventTriggers, thogh honestly i have NO idea what there can be.
}
