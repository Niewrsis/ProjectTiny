using Game.PlayerSystem;
using Game.PlayerSystem.View;
using UnityEngine;

namespace Game.InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Player player;
        [SerializeField] private PlayerFormChangingView playerFormView;

        private PlayerInvoker _playerInvoker;
        private Player _playerCopy;
        private bool _isGround;
        private bool _isMoving;

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
            _isMoving = false;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                _isMoving = true;
            }
            float xMove = Input.GetAxis("Horizontal");
            _playerInvoker.InvokeMove(xMove, _isMoving);
        }
        private void ReadJumpInput()
        {
            if (IsGrounded(_playerCopy.Rb, _playerCopy.Transform) || (player.JumpAmounts < 2 && player.FormID == 1))

            if (Input.GetKeyDown(KeyCode.Space))
            {
                    _playerInvoker.InvokeJump();
                    player.JumpAmounts++;
            }
        }
        private void ReadChangeFormInput()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _playerInvoker.InvokeChangeForm(playerFormView);
                if (player.FormID == 2)
                {
                    // TODO player hitbox collider is split by half
                }
            }
        }
        private bool IsGrounded(Rigidbody2D rb, Transform transform)
        {
            float rayDistance = transform.localScale.y/2 + 0.05f;

            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));

            if (hit.collider != null)
            {
                _isGround = true;
                player.JumpAmounts = 0;
                return _isGround;
            }
            else
            {
                _isGround = false;
                return _isGround;
            }
        }
    }
}