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

    [Tooltip("Event List. It will go through the events, and execute one by one. You know, like code?" +
        "\n\nCreate new Events via right click (if all is set up correctly), shove values as needed and hope they work!" +
        "\nPlease store new Events in their own folder, with the scene affected also in their own folder." +
        "\nMaybe something like... SceneName/Events/StupidEventThatBreaksEveryOtherTime." +
        "\nOr don't. It won't be my mess to untangle after this...")]
    public List<Event> events = new();

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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Add(collision.gameObject);
        }
    }
    // end ENTERS


    //EXITS
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Remove(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerList.Remove(collision.gameObject);
        }
        
    }
    //end EXITS

    // TODO implement better! NOW.
    private void LateUpdate()
    {
        if (playerList.Count > 0)
        {
            foreach (GameObject player in playerList)
            {
                if (trigger.ShouldTrigger(this, player) && !usedOnce)
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
        StartCoroutine(ExecuteEvents(player));
    }

    private IEnumerator ExecuteEvents(Player player)
    {
        for (int ticker = 0; ticker < events.Count; ticker++)
        {
            Event e = events[ticker];
            if (e != null)
            {
                if (!e.eventIsBusy)
                {
                    e.Execute(this, player);
                }
                else
                {
                    yield return null;
                    if (ticker > 0)
                    {
                        ticker--;
                    }
                }
            }
        }
        SetBusy(false);
        if (oneTimeUse) usedOnce = true;
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
