using Game.PlayerSystem;
using UnityEngine;

namespace Game.InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Player player;

        private PlayerInvoker _playerInvoker;

        private void Awake()
        {
            _playerInvoker = new(player);
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
    }
}