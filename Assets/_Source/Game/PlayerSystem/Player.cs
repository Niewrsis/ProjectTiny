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
        [field: SerializeField] public float JumpForce { get; private set; }
        [HideInInspector] public int FormID;
        [HideInInspector] public int JumpAmounts;

        private Rigidbody2D _rb;
        private Transform _transform;
        private SpriteRenderer _playerSR;
        public Rigidbody2D Rb => _rb;
        public Transform Transform => _transform;
        public SpriteRenderer PlayerSR => _playerSR;
        private void Awake()
        {
            _playerSR = GetComponent<SpriteRenderer>();
            _transform = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}