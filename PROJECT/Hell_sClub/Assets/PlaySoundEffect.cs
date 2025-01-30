using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : StateMachineBehaviour
{
    public AudioSource SFX;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SFX.Play();
    }

}
