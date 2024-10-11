using System.Collections;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "WaitUntilInput", menuName = "Events/WaitUntilInput")]
public class WaitUntilInputEvent : Event
{
    [Tooltip("Timeout in seconds before actually start reading the input key.")]
    public float timeout;

    [Tooltip("Key which can be read upon pressing to continue dialogue.")]
    public KeyCode key;

    public override void Execute(EventTrigger eventTrigger, Player player)
    {
        base.Execute(eventTrigger, player);
        eventIsBusy = true; // we're not actually done yet
    }

    public override void Main(EventTrigger eventTrigger, Player player)
    {
        GameObject slave = new("SlaveForInputWaiting");
        MonoBehaviour executioner = slave.AddComponent<Blank>();

        executioner.StartCoroutine(waitForInput(slave));
        // this is stupid. We call a newly created MonoBehaviour via a new Game Object,
        // just to call this ScriptableObject's Coroutine. I mean it works? I guess?
    }

    private IEnumerator waitForInput(GameObject slave)
    {
        yield return new WaitForSeconds(timeout);
        while (!Input.GetKey(KeyCode.R) && !Input.GetKeyDown(KeyCode.E))
        {
            yield return null;   // aand now we keep on promising that something will happen.
        }
        Destroy(slave);
        eventIsBusy = false;  // bucket
    }
}