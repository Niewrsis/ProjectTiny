using Game.PlayerSystem;
using UnityEngine;

namespace Game.InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Player player;

        private PlayerInvoker _playerInvoker;
        private Player _playerCopy;
        private bool _isGround;

        private void Awake()
        {
            _playerInvoker = new(player);
        }
        private void Start()
        {
            _playerCopy = _playerInvoker.GetPlayer();
        }
        private void Update()
        {
            ReadChangeFormInput();
            ReadJumpInput();
        }
        private void FixedUpdate()
        {
            ReadMoveInputs();
        }
        private void ReadMoveInputs()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                float xMove = Input.GetAxis("Horizontal");
                _playerInvoker.InvokeMove(xMove);
            }
        }
        private void ReadJumpInput()
        {
            if (IsGrounded(_playerCopy.Rb, _playerCopy.Transform))

            if (Input.GetKeyDown(KeyCode.Space))
            {
                    _playerInvoker.InvokeJump();
            }
        }
        private void ReadChangeFormInput()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _playerInvoker.InvokeChangeForm();
            }
        }
        private bool IsGrounded(Rigidbody2D rb, Transform transform)
        {
            float rayDistance = transform.localScale.y/2 + 0.05f;

            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));

            if (hit.collider != null)
            {
                _isGround = true;
                Debug.Log(_isGround);
                return _isGround;
            }
            else
            {
                _isGround = false;
                Debug.Log(_isGround);
                return _isGround;
            }
        }
    }
}