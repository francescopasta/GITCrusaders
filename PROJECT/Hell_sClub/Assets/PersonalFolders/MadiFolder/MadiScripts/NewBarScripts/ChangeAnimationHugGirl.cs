using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationHugGirl : MonoBehaviour
{
    public GameObject targetObject; // Reference to the target object with the Animator
    private Animator targetAnimator;

    void Start()
    {
        // Find the Animator on the target object
        if (targetObject != null)
        {
            targetAnimator = targetObject.GetComponent<Animator>();
            if (targetAnimator == null)
            {
                Debug.LogError("Animator not found on the target object!");
            }
        }
        else
        {
            Debug.LogError("Target object not assigned!");
        }
    }

    // Function triggered by the animation event
    public void ChangeTargetAnimationState(string newState)
    {
        if (targetAnimator != null)
        {
            targetAnimator.Play(newState); // Play the specified animation
        }
        else
        {
            Debug.LogWarning("Animator on the target object is not assigned or found!");
        }
    }
}
