using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEndEventHugging : MonoBehaviour
{
    public GameObject player; // The player object to disable
    public GameObject npc; // The NPC object to disable
    public GameObject objectToEnable; // The object to enable (with camera as child)

    // This method will be called by the animation event at the end of the animation
    public void OnAnimationEnd()
    {
        // Disable the object that was enabled
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);
        }

        // Enable the player and NPC
        if (player != null)
        {
            player.SetActive(true);
        }
        if (npc != null)
        {
            npc.SetActive(true);
        }
    }
}
