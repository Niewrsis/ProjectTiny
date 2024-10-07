using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerSystem
{
    public class IsGroundedPlayer : MonoBehaviour
    {
        public bool IsPlayerGrounded;
        private void OnTriggerEnter2D(Collider2D collision)
            if (collision != null)
            {
                IsPlayerGrounded = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            IsPlayerGrounded = false;
        }
    }
}