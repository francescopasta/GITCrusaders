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
    public GameObject bottleToDisable; // The GameObject to turn off on interaction
    public GameObject bottleHandToEnable; // The GameObject to turn on on interaction
    public Animator cameraAnimator; // The Animator component for the camera
    public string animationStateName; // The name of the animation state to trigger

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

        // Ensure the initial states of the objects
        if (bottleToDisable != null) bottleToDisable.SetActive(true);
        if (bottleHandToEnable != null) bottleHandToEnable.SetActive(false);
    }

    void Update()
    {
        // Check for Space key press while in range and if action hasn't been triggered
        if (isPlayerInRange && !actionTriggered)
        {
            // Show the interaction prompt
            if (interactionPromptUI != null) interactionPromptUI.SetActive(true);

            // Trigger action on Space key press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TriggerAction();
            }
        }
        else
        {
            // Hide the interaction prompt if out of range or action is already triggered
            if (interactionPromptUI != null) interactionPromptUI.SetActive(false);
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

    private void TriggerAction()
    {
        actionTriggered = true;

        // Permanently disable the bottle and enable the hand
        if (bottleToDisable != null) bottleToDisable.SetActive(false);
        if (bottleHandToEnable != null) bottleHandToEnable.SetActive(true);

        // Trigger the camera animation state
        if (cameraAnimator != null && !string.IsNullOrEmpty(animationStateName))
        {
            cameraAnimator.Play(animationStateName);
        }

        // Start moving the NPC to the target position
        if (npcToMove != null && targetPositionObject != null)
        {
            isMoving = true;
        }

        // Hide the interaction prompt
        if (interactionPromptUI != null) interactionPromptUI.SetActive(false);
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

            // Hide the interaction prompt
            if (interactionPromptUI != null) interactionPromptUI.SetActive(false);
        }
    }
}
