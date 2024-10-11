using System.Collections;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "WaitUntilInput", menuName = "Events/WaitUntilInput")]
public class WaitUntilInputEvent : Event
{
    [Tooltip("Key which can be read upon pressing to continue dialogue.")]
    public KeyCode key;

    public override void Execute(EventTrigger eventTrigger, Player player)
    {
        eventIsBusy = true;
        Main(eventTrigger, player);
    }

    public override void Main(EventTrigger eventTrigger, Player player)
    {
        GameObject slave = new GameObject("SlaveForInputWaiting");
        MonoBehaviour executioner = slave.AddComponent<Blank>();
        executioner.StartCoroutine(WaitForInput(slave, key));
    }

    private IEnumerator WaitForInput(GameObject slave, KeyCode key)
    {
        bool keyPressed = false;
        while (!keyPressed)
        {
            if (Input.GetKeyDown(key))
            {
                keyPressed = true;
            }
            yield return null;
        }
        eventIsBusy = false; // bucket
        Destroy(slave);
    }
}
