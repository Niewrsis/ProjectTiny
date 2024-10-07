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
            ReadJumpDownInput();
        }
        private void FixedUpdate()
        {
            ReadMoveInputs();
        }
        private void ReadJumpDownInput()
        {
            if (Input.GetKey(KeyCode.S))
            {
            _playerInvoker.InvokeJumpDown(player);
            } else
            {
                _playerCopy.isTryingToJumpDown = false; // todo either make it better or just forget about it and cry aobut it later
            }
        }
        private void ReadMoveInputs()
        {
            _isMoving = false;
            float xMove = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                _isMoving = true;
                if (xMove > 0)
                {
                    _playerCopy.PlayerSR.flipX = false;
                } else
                {
                    _playerCopy.PlayerSR.flipX = true;
                }
            }
            _playerInvoker.InvokeMove(xMove, _isMoving);

        }
        private void ReadJumpInput()
        {
            if (player.FormID == 0) return;
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
                BoxCollider2D boxCollider2D = _playerCopy.GetComponent<BoxCollider2D>();
                switch (player.FormID)
                {
                    // sjit is fuck but fuck is balls
                    // in other words, we only have today to finish everything
                    case 0:
                        boxCollider2D.size = new Vector2(2.35f, 2.35f); // too big for vect3 1 1 1, so no jumping lol
                        break;
                    case 1:
                        boxCollider2D.size = new Vector2(1.35f, 1.9f); // doublejump, so make small enuff to actually be grounded
                        break;
                    case 2:
                        boxCollider2D.size = new Vector2(1, 1.3f); 
                        break;
                }
            }
        }
        private bool IsGrounded(Rigidbody2D rb, Transform transform)
        {
            float rayDistance = transform.localScale.y;

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