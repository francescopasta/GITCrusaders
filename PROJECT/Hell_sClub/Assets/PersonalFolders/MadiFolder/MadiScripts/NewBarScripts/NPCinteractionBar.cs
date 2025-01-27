using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinteractionBar : MonoBehaviour
{
    public GameObject player; // Reference to the player
    public GameObject npcToMove; // The NPC that will move
    public Transform targetPositionObject; // The target GameObject to move towards
    public GameObject interactionPromptUI; // The UI prompt
    public float moveSpeed = 2f; // Speed at which the NPC moves

    private bool isPlayerInRange = false; // Tracks if the player is near the NPC
    private bool actionTriggered = false; // Ensures the action is only triggered once
    private bool isMoving = false; // Tracks if the NPC is currently moving

    void Start()
    {
        // Hide the interaction prompt at the start
        if (interactionPromptUI != null)
        {
            interactionPromptUI.SetActive(false);
        }
    }

    void Update()
    {
        // Show the interaction prompt if the player is in range
        if (isPlayerInRange && !actionTriggered)
        {
            interactionPromptUI.SetActive(true);

            // Check for Space key press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TriggerNPCAction();
            }
        }
        else if (!isPlayerInRange)
        {
            interactionPromptUI.SetActive(false);
        }

        // Smoothly move the NPC to the target position
        if (isMoving && npcToMove != null && targetPositionObject != null)
        {
            npcToMove.transform.position = Vector3.MoveTowards(
                npcToMove.transform.position,
                targetPositionObject.position,
                moveSpeed * Time.deltaTime
            );

            // Stop moving when the NPC reaches the target position
            if (Vector3.Distance(npcToMove.transform.position, targetPositionObject.position) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    private void TriggerNPCAction()
    {
        actionTriggered = true;
        interactionPromptUI.SetActive(false);

        // Start moving the NPC to the target position
        if (npcToMove != null && targetPositionObject != null)
        {
            isMoving = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the NPC's interaction range
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player leaves the NPC's interaction range
        if (other.gameObject == player)
        {
            isPlayerInRange = false;
        }
    }
}
