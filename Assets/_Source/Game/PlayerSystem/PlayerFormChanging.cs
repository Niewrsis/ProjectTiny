using Game.PlayerSystem.View;
using UnityEngine;

namespace Game.PlayerSystem
{
    public class PlayerFormChanging
    {
        private PlayerFormChangingView _formView;

        public void ChangeNextForm(Animator playerSprite, Player player, PlayerFormChangingView playerFormView)
        {
            _formView = playerFormView;
            if (player.FormID == 2)
            {
                player.FormID = 0;
            }
            else
            {
                player.FormID++;
            }
            _formView.ChangeForm(player.FormID, playerSprite);
        }
    }
}