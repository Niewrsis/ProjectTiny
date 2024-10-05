using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "TeleportGameObject", menuName = "Events/TeleportGameObject")]
public class TeleportGameObjectEvent : Event
{
    [Tooltip("GameObject, or the subject that we will teleport.")]
    public GameObject gameObject;

    [Tooltip("If this won't be empty, but GameObject will be, we will fall back to trying to Find it by name.")]
    public string gameObjectName;

    [Tooltip("Vector3 position of where we will teleport it to. If this is somehow null, nothing will happen.")]
    public Vector3 destination;

    public override void Main(EventTrigger eventTrigger, Player player)
    {
        if (gameObject == null)
        {
            if (gameObjectName.Length > 0)
            {
                gameObject = GameObject.Find(gameObjectName);
                if (gameObject == null)
                {
                    Debug.LogError("Failed to find " + gameObjectName);
                    return;
                }
            }

            else
            {
                Debug.LogError("Given GameObject is null, and String to Find was Empty.");
                return;
            }
        };

        if (destination == null)
        {
            Debug.LogError("Destination was null.");
            return;
        }
        gameObject.transform.position = destination;
    }
}