using Game.PlayerSystem.View;

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
        public void InvokeMove(float xMove)
        {
            _playerMovement.Move(_player.Rb, _player.MovementSpeed, xMove);
        }
        public void InvokeJump()
        {
            _playerMovement.Jump(_player.Rb, _player.JumpForce);
        }
        public void InvokeChangeForm()
        {
            _playerForm.ChangeNextForm(_player.PlayerSR, _player);
        }
        public Player GetPlayer()
        {
            return _player;
        }
    }
}