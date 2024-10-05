namespace Game.PlayerSystem
{
    public class PlayerInvoker
    {
        private PlayerMovement _playerMovement;
        private Player _player;

        public PlayerInvoker(Player player)
        {
            _playerMovement = new();
            _player = player;
        }
        public void InvokeMove(float xMove)
        {
            _playerMovement.Move(_player.Rb, _player.MovementSpeed, xMove);
        }
    }
}