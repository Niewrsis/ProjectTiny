using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerSystem;

[CreateAssetMenu(fileName = "ConditionalBranch", menuName = "Events/ConditionalBranch")]
public class ConditionalBranchEvent : Event
{
    [Tooltip("if you see this, scream at dev, this isn't supposed to be a fucking boolean, this is supposed to be wayyy too overcomplicated.")]
    public bool condition;

    [Tooltip("This is a list of events, that will happen if the condition is satisfied.")]
    public List<Event> trueEvent;

    [Tooltip("This is a list of events, that will happen if the condition is unsatisfied.")]
    public List<Event> falseEvent;

    public override void Main(EventTrigger eventTrigger, Player player)
    {
        Debug.LogWarning("this is untested please slam dunk AnTeaVirus as it's his bundle of trash that's making this bad");
        if (condition)
        {
            foreach (Event yebani in trueEvent)
            {
                yebani.Main(eventTrigger, player);
            }
        }
        else
        {
            foreach (Event yebani in falseEvent)
            {
                yebani.Main(eventTrigger, player);
            }
        }
    }
}