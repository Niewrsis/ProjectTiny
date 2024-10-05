using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerSystem.View
{
    public class PlayerFormChangingView : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _formSprites;

        public void ChangeForm(int formID, SpriteRenderer playerSprite)
        {
            if (playerSprite != null)
            {
                if (formID >= 0 && formID < _formSprites.Count)
                {
                    playerSprite.sprite = _formSprites[formID];
                    Debug.Log($"Form changed - {formID}");
                }
                else
                {
                    Debug.LogError("Invalid form ID: " + formID);
                }
            }
            else
            {
                Debug.LogError("playerSprite is null");
            }
        }
    }
}