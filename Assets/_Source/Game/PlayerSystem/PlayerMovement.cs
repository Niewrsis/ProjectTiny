using UnityEngine;

namespace Game.PlayerSystem
{
    public class PlayerMovement
    {
        public void Move(Rigidbody2D rb, float moveSpeed, float xMove)
        {
            rb.velocity = new Vector2(xMove * moveSpeed, rb.velocity.y);
        }
        public void Jump(Rigidbody2D rb, float jumpForce)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}