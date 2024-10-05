using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        public void Move(Rigidbody2D rb, float moveSpeed, float xMove)
        {
            rb.velocity = new Vector2(xMove, 0) * moveSpeed;
        }
    }
}