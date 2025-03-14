using System.Collections.Generic;
using UnityEngine;
using Triggers;
using System.Collections;
using Game.PlayerSystem;

public class EventTrigger : MonoBehaviour
{
    [Tooltip("Trigger. Type of trigger given to it will decide when it will execute the events. Types are within Trigger.cs, if you wish to see." +
        "\nThere, you can add more if you would like to do so. I am not sure why would you, as it would change WHEN this starts it's events.")]


    public string triggerType;
    public Trigger trigger;


    public bool oneTimeUse = false;
    public bool usedOnce = false;

    [Tooltip("Please do not edit this in the editor. It's supposed to be just for the function.")]
    private bool busyExecuting = false;

    // TODO: This motherfucker needs to somehow hint to the player that they can interact with X or Y.
    // public GameObject interactionNotifier;

    [Tooltip("Player List. You better hope inside are players, because otherwise there'll be a ton of LogErrors.")]
    public List<GameObject> playerList;
    public GameObject lastPlayer;

    [Tooltip("Event List. It will go through the events, and execute one by one. You know, like code?" +
        "\n\nCreate new Events via right click (if all is set up correctly), shove values as needed and hope they work!" +
        "\nPlease store new Events in their own folder, with the scene affected also in their own folder." +
        "\nMaybe something like... SceneName/Events/StupidEventThatBreaksEveryOtherTime." +
        "\nOr don't. It won't be my mess to untangle after this...")]
    public List<Event> events = new();
    public Event currentEvent;

    private void Start()
    {
        TriggerAssigner assigner = new();
        trigger = assigner.AssignByName(triggerType);

        if (GetComponent<Collider>() == null || GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning("I didn't find collider on me. I might be blind, but please check it out.");
        }
    }

    // ENTERS
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Add(collision.gameObject);
            lastPlayer = collision.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Add(collision.gameObject);
            lastPlayer = collision.gameObject;
        }
    }
    // end ENTERS


    //EXITS
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Remove(collision.gameObject);
            lastPlayer = null;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Remove(collision.gameObject);
            lastPlayer = null;
        }
        
    }
    //end EXITS

    // TODO implement better! NOW.
    private void LateUpdate()
    {
        if (oneTimeUse && usedOnce) return;

        if (playerList.Count > 0)
        {
            foreach (GameObject player in playerList)
            {
                if (trigger.ShouldTrigger(this, player))
                {
                    // this is bad. time to move on and make even more mistakes
                    TriggerEvents(player.GetComponentInParent<Player>());
                }

            }
        }
    }

    internal void TriggerEvents(Player player)
    {
        if (busyExecuting) return;
        SetBusy(true);
        ResetEvents();  // holy shit nevermind i'm starting to hate scriptable objects
        StartCoroutine(ExecuteEvents(player));
    }

    private void ResetEvents()
    {
        foreach (Event e in events)
        {
            e.eventIsBusy = false;
        }
    }

    private IEnumerator ExecuteEvents(Player player)
    {
        Debug.Log("start");
        for (int ticker = 0; ticker < events.Count; ticker++)
        {
            Event currentEvent = events[ticker];
            this.currentEvent = currentEvent;
            if (currentEvent != null)
            {
                // Check if the previous event is busy
                if (ticker > 0 && events[ticker - 1].eventIsBusy)
                {
                    // If the previous event is busy, wait until it is not busy
                    while (events[ticker - 1].eventIsBusy)
                    {
                        yield return null;
                    }
                }

                if (!currentEvent.eventIsBusy)
                {
                    currentEvent.Execute(this, player);
                }
                else
                {
                    // If the current event is busy, wait until it is not busy
                    while (currentEvent.eventIsBusy)
                    {
                        yield return null;
                    }
                    // Decrement the ticker to ensure we don't skip the current event
                    if (ticker > 0)
                    {
                        ticker--;
                    }
                }
            }
        }
        SetBusy(false);
        if (oneTimeUse) usedOnce = true;
        Debug.Log("end");
        yield break;
    }


    internal bool IsPlayerTouching(GameObject player)
    {
        bool test1 = playerList.Contains(player);
        return test1;
    }

    internal void SetBusy(bool busy)
    {
        busyExecuting = busy;
    }
}
