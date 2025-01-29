using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANimTriggerTrig : MonoBehaviour
{
    public Animator targetAnimator; // Reference to the target Animator
    public string triggerParameterName; // Name of the trigger parameter to trigger

    // This function will be called as an animation event
    public void TriggerAnimation()
    {
        if (targetAnimator != null && !string.IsNullOrEmpty(triggerParameterName))
        {
            targetAnimator.SetTrigger(triggerParameterName);
        }
        else
        {
            Debug.LogWarning("Target Animator or Parameter Name not set on " + gameObject.name);
        }
    }
}
