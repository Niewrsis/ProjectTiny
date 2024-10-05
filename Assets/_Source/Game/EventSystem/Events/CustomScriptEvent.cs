using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "CustomScript", menuName = "Events/CustomScript")]
public class CustomScriptEvent : Event
{
    [Tooltip("Cast your MonoBehaviour script into CustomScriptInjector, and make sure your class has 'ExecuteDuringCustomScript' method.")]
    public CustomScriptInjector totallyNotMonoBehaviorWithExtraMethod;

    public override void Main(EventTrigger eventTrigger, Player player)
    {
        if (totallyNotMonoBehaviorWithExtraMethod != null)
        {
            totallyNotMonoBehaviorWithExtraMethod.Execute();
        }
    }
}