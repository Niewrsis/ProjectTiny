using Game.PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Box : MonoBehaviour
{
    private Rigidbody2D rb;
    private int formToBePushedWith = 0;

    private Player lastPlayer;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lastPlayer = collision.GetComponent<Player>();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lastPlayer = collision.gameObject.GetComponent<Player>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.mass = 125;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (lastPlayer.FormID == formToBePushedWith)
            {
                rb.mass = 25;
            }
            else
            {
                rb.mass = 125;
            }
        }
    }
}
