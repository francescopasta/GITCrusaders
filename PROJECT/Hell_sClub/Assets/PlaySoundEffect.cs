using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : StateMachineBehaviour
{
    public AudioSource fallingSFX;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fallingSFX.Play();
    }

}
