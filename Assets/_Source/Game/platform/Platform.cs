using System;
using UnityEngine;
using Game.PlayerSystem;

public class PlatformController : MonoBehaviour
{
    public GameObject tilemapHitbox;
    public GameObject triggerArea;
    public LayerMask playerLayer = 3; // i think this is player, please change if not
    public int groundLayer = 6; // pickin a layer breaks it, so um.. pls input int and not layermask or all is break :V
            
    public CompositeCollider2D compositeCollider;
    public bool isPlayerCollisionIgnored = false;
    public bool playerInsideMe = false;

    private void Start()
    {
        compositeCollider = tilemapHitbox.GetComponent<CompositeCollider2D>();

        tilemapHitbox.layer = groundLayer;

        if (playerLayer == 0 || groundLayer == 0)
        Debug.Log("PlatformController: player or ground layer may be set to 0, please check if correct");
    }

    private void Update()
    {

    }

    public void PlayerIsInsideOfMe(GameObject player)
    {
        if (!player.TryGetComponent<Rigidbody2D>(out Rigidbody2D playerRigidbody))
        {
            return;
        }

        Player playerController = player.GetComponent<Player>();

        bool isFallingThrough = playerRigidbody.velocity.y < 0.2f && playerController.isTryingToJumpDown;

        bool isJumpingThrough = playerRigidbody.velocity.y >= 0.5f && !playerController.isTryingToJumpDown;

        if (isFallingThrough || isJumpingThrough)
        {
            IgnorePlayerCollision();
            playerInsideMe = true;
        }
        else
        {
            RestorePlayerCollision();
            playerInsideMe = false;
        }
    }


    public void IgnorePlayerCollision()
    {
        if (!isPlayerCollisionIgnored)
        {
            compositeCollider.excludeLayers = playerLayer;
            tilemapHitbox.layer = 0;    // default
            isPlayerCollisionIgnored = true;
        }
    }

    public void RestorePlayerCollision()
    {
        if (isPlayerCollisionIgnored)
        {
            compositeCollider.excludeLayers = 0;
            tilemapHitbox.layer = groundLayer;
            isPlayerCollisionIgnored = false;
        }
    }
}
