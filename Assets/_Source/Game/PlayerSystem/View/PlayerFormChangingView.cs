using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Game.PlayerSystem.View
{
    public class PlayerFormChangingView : MonoBehaviour
    {
        [SerializeField] private List<AnimatorController> _formAnimations;

        public void ChangeForm(int formID, Animator playerAnimator)
        {
            if (playerAnimator != null)
            {
                if (formID >= 0 && formID < _formAnimations.Count)
                {
                    playerAnimator.runtimeAnimatorController = _formAnimations[formID];
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