using System;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerSystem;

/**
 * Purpose:
 * The purpose of this script is to provide a flexible and extensible way to handle trigger events in a game.
 * Each trigger class is designed to respond to specific conditions, such as player actions, proximity, et cetera.
 * 
 * Tampering Notes:
 * If you need to modify or extend this script, please note the following:
 * - The `Trigger` abstract class is not intended to be used directly. Instead, use one of the concrete trigger classes (e.g., `ActionButtonTrigger`, `PlayerTouchTrigger`, etc.).
 * - When creating a new trigger class, ensure that it inherits from the `Trigger` abstract class and overrides the `ShouldTrigger` method.
 * - Be aware that the `ShouldTrigger` method is called repeatedly, so optimize your logic to avoid performance issues.
 * - If you're modifying an existing trigger class, make sure to test your changes thoroughly to avoid introducing bugs or unexpected behavior.
 * - They should *not* contain variables within themselves. If they will at some point, please implement that better than whatever I have done to make this work.
 * - BTW this isn't supposed to be edited in the middle of the game within the editor, so if you're thinking that's possible, please do it responsibly. Drink responsibly.
 */
namespace Triggers
{
    [System.Serializable]
    public class Trigger
    {
        public bool global = false;
        public virtual bool ShouldTrigger(EventTrigger eventTrigger, GameObject player) {
            // never trigger, as this isn't really supposed to be used. whoever does can eat a walnut.
            Debug.Log("Default, functionless trigger has been initiated.");
            return false;
        }
    }

    public class TriggerAssigner
    {
        private static readonly Dictionary<string, Type> triggerTypesByName = new Dictionary<string, Type>
        {
            { nameof(PlayerAndActionButtonTrigger), typeof(PlayerAndActionButtonTrigger) },
            { nameof(PlayerTouchTrigger), typeof(PlayerTouchTrigger) },
            { nameof(AlwaysRunTrigger), typeof(AlwaysRunTrigger) },
            { nameof(GlobalActionButtonTrigger), typeof(GlobalActionButtonTrigger) },
            { nameof(NeverRunTrigger), typeof(NeverRunTrigger) }
        };

        private static readonly Dictionary<int, Type> triggerTypesByID = new Dictionary<int, Type>
        {
            { (int)TriggerType.PlayerAndActionButtonTrigger, typeof(PlayerAndActionButtonTrigger) },
            { (int)TriggerType.PlayerTouchTrigger, typeof(PlayerTouchTrigger) },
            { (int)TriggerType.AlwaysRunTrigger, typeof(AlwaysRunTrigger) },
            { (int)TriggerType.GlobalActionButtonTrigger, typeof(GlobalActionButtonTrigger) },
            { (int)TriggerType.NeverRunTrigger, typeof(NeverRunTrigger) }
        };

        public Trigger AssignByName(string name)
        {
            if (triggerTypesByName.TryGetValue(name, out Type eventType))
            {
                return (Trigger)Activator.CreateInstance(eventType);
            }
            return new Trigger(); // Default event if not found
        }

        public Trigger AssignByID(int id)
        {
            if (triggerTypesByID.TryGetValue(id, out Type eventType))
            {
                return (Trigger)Activator.CreateInstance(eventType);
            }
            return new Trigger(); // Default event if not found
        }


        public enum TriggerType
        {
            Trigger = 0,
            PlayerAndActionButtonTrigger = 1,
            PlayerTouchTrigger = 2,
            AlwaysRunTrigger = 3,
            NeverRunTrigger = 4,
            GlobalActionButtonTrigger = 5,
            // and so on.
        }
    }

    public class PlayerAndActionButtonTrigger : Trigger
    {
        public override bool ShouldTrigger(EventTrigger eventTrigger, GameObject player)
        {
            bool test2 = eventTrigger.playerList.Contains(player);
            // player in trigger's list

            bool test4;
            if (eventTrigger.TryGetComponent(out Collider2D _))
            {
                test4 = Vector2.Distance(player.transform.position, eventTrigger.transform.position) < 15f;
            } else
            {
                test4 = Vector3.Distance(player.transform.position, eventTrigger.transform.position) < 15f;
            }
            // distance between player and trigger < player distance interact limit

            bool test5 = Input.GetKeyDown(KeyCode.E); // please kill me and delete everything that is here
            // actually wants to interact with the thing. it took me too long

            return test2 && test4 && test5;
        }
    }

    public class GlobalActionButtonTrigger : Trigger
    {
        public new bool global = true;
        public override bool ShouldTrigger(EventTrigger eventTrigger, GameObject player)
        {
            bool test1 = Input.GetKeyDown(KeyCode.E); 
            // player isn't really needed here...

            return test1;
        }
    }

    public class PlayerTouchTrigger : Trigger
    {
        public override bool ShouldTrigger(EventTrigger eventTrigger, GameObject player)
        {
            // player touches trigger. is all we need.
            return eventTrigger.IsPlayerTouching(player);
        }
    }

    public class AlwaysRunTrigger : Trigger
    {
        public override bool ShouldTrigger(EventTrigger eventTrigger, GameObject player)
        {
            // always trigger
            return true;
        }
    }

    public class NeverRunTrigger : Trigger
    {
        public override bool ShouldTrigger(EventTrigger eventTrigger, GameObject player)
        {
            // always ignore. i find this funny. nobody else will.
            return false;
        }
    }

}
