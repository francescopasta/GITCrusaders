using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBoolTrigging : MonoBehaviour
{
    public Animator targetAnimator; // Reference to the target Animator
    public string stateName; // Name of the animation state to play

    // This function will be called as an animation event
    public void TriggerAnimation()
    {
        if (targetAnimator != null && !string.IsNullOrEmpty(stateName))
        {
            targetAnimator.Play(stateName);
        }
        else
        {
            Debug.LogWarning("Target Animator or State Name not set on " + gameObject.name);
        }
    }
}
