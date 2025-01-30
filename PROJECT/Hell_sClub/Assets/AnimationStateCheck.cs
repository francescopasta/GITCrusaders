using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateCheck : MonoBehaviour
{
    public Animator animator;
    public GameObject audioSource;

    public string targetStateName = "GirlWalk"; // Name of the animation state

   
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(targetStateName) && !audioSource.activeSelf)
        {
            audioSource.SetActive(true);
        }
    }
}
