using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPChuggingClub : MonoBehaviour
{
    public GameObject player; // The player object to disable
    public GameObject npc; // The NPC object to disable
    public GameObject objectToEnable; // The object to enable (with camera as child)

    private bool hasTriggered = false; // Prevent multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger and it hasn't been triggered yet
        if (other.gameObject == player && !hasTriggered)
        {
            hasTriggered = true; // Ensure this triggers only once

            // Enable the specified object and its camera
            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true);

                // Enable camera if it's a child of the object
                Transform camera = objectToEnable.transform.Find("Camera");
                if (camera != null)
                {
                    camera.gameObject.SetActive(true);
                }
            }

            // Disable the player
            if (player != null)
            {
                player.SetActive(false);
            }

            // Disable the NPC
            if (npc != null)
            {
                npc.SetActive(false);
            }
        }
    }
}
