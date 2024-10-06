using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.KeySystem
{
    public class Key : MonoBehaviour
    {
        public static UnityAction IsKey;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            IsKey?.Invoke();
            Destroy(gameObject);
        }
    }
}