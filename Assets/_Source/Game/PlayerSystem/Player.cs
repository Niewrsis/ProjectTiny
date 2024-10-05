using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [HideInInspector] public int FormID;

        private Rigidbody2D _rb;
        private SpriteRenderer _playerSR;
        public Rigidbody2D Rb => _rb;
        public SpriteRenderer PlayerSR => _playerSR;
        private void Awake()
        {
            _playerSR = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}