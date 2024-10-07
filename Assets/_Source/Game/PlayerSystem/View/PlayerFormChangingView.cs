using System.Collections.Generic;
using UnityEngine;

namespace Game.PlayerSystem.View
{
    public class PlayerFormChangingView : MonoBehaviour
    {
        [SerializeField] private List<RuntimeAnimatorController> _formAnimations;

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
                Debug.LogError("playerAnimator is null");
            }
        }
    }
}
