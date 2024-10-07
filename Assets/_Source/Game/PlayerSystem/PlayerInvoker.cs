using Game.PlayerSystem.View;
using UnityEngine;

namespace Game.PlayerSystem
{
    public class PlayerInvoker
    {
        private PlayerMovement _playerMovement;
        private PlayerFormChanging _playerForm;
        private Player _player;

        public PlayerInvoker(Player player)
        {
            _playerMovement = new();
            _playerForm = new();
            _player = player;
        }
        public void InvokeMove(float xMove, bool isMoving)
        {
            _playerMovement.Move(_player.Rb, _player.MovementSpeed, xMove, isMoving);
        }
        public void InvokeJump()
        {
            _playerMovement.Jump(_player.Rb, _player.JumpForce);
        }
        public void InvokeChangeForm(PlayerFormChangingView playerFormView)
        {
            _playerForm.ChangeNextForm(_player.Anim, _player, playerFormView);
        }
        public void InvokeJumpDown(Player player)
        {
            _playerMovement.JumpDown(player);
        }
        public void InvokeDie(Player player)
        {
            
        }
        public Player GetPlayer()
        {
            return _player;
        }
    }
}