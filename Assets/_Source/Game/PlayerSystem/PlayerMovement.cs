using UnityEngine;

namespace Game.PlayerSystem
{
    public class PlayerMovement
    {
        public void Move(Rigidbody2D rb, float moveSpeed, float xMove, bool isMoving)
        {
            rb.velocity = new Vector2(xMove * moveSpeed, rb.velocity.y);
            if (isMoving == false) rb.velocity = new Vector2 (0, rb.velocity.y);
        }
        public void Jump(Rigidbody2D rb, float jumpForce)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        public void JumpDown(Player player)
        {
            player.isTryingToJumpDown = true;
        }
    }
}