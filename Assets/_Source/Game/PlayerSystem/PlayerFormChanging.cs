using Game.PlayerSystem.View;
using UnityEngine;

namespace Game.PlayerSystem
{
    public class PlayerFormChanging
    {
        private PlayerFormChangingView _formView;

        public void ChangeNextForm(SpriteRenderer playerSprite, Player player)
        {
            if (player.FormID == 2)
            {
                player.FormID = 0;
                Debug.Log($"Form ID - {player.FormID}");
            }
            else
            {
                player.FormID++;
                Debug.Log($"Form ID - {player.FormID}");
            }
            _formView.ChangeForm(player.FormID, playerSprite);
        }
    }
}