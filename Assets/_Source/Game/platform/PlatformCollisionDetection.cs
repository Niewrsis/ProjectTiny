using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionDetection : MonoBehaviour
{
    [SerializeField]
    public PlatformController parent;

    // somehow i need to check if the trigger area is above player, and if so
    // actually what if i just check the mf for >0 .y velocity?
    void Start()
    {
        if (parent == null) Debug.LogError("PlatformCollisionDetection: Please give me a parent, or I will remain an orphan.");
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parent.PlayerIsInsideOfMe(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parent.PlayerIsInsideOfMe(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parent.RestorePlayerCollision(); // it left us, so since player is outside of platform, we can restore it's previous state
        }
    }
}
