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
        [HideInInspector] public bool isTryingToJumpDown;
        [HideInInspector] public bool IsDead;

        private Animator _anim;
        private Rigidbody2D _rb;
        private Transform _transform;
        private SpriteRenderer _playerSR;

        public Animator Anim => _anim;
        public Rigidbody2D Rb => _rb;
        public Transform Transform => _transform;
        public SpriteRenderer PlayerSR => _playerSR;
        private void Awake()
        {
            _playerSR = GetComponent<SpriteRenderer>();
            _transform = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        public void DIE()
        {
            // sjitcode 'ere i come

            MovementSpeed = 0;
            JumpForce = 0;
            IsDead = true;

            StartCoroutine(nameof(DeathCutscene));
        }
        private IEnumerator DeathCutscene()
        {
            yield break; ;
        }
    }
}