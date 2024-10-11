using System.Collections;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "EnableObject", menuName = "Events/EnableObject")]
public class EnableObjectEvent : Event
{
    [Tooltip("Object we enable.")]
    public GameObject gameObject;

    [Tooltip("If the previous is empty, I can be filled out to find the item by name.")]
    public string findThisName;

    public override void Main(EventTrigger eventTrigger, Player player)
    {
        if (gameObject == null && findThisName.Length > 0)
        {
            gameObject = GameObject.Find(findThisName);
        }
        if (gameObject == null)
        {
            Debug.LogError("Did not have, nor did I find object by that name, if there were any. You didn't try to find an object with no name, did you?");
            return;
        }
        gameObject.SetActive(true);
    }
}