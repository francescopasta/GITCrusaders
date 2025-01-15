using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggersControler : MonoBehaviour
{
    public Transform target; // The character the capsule will follow
    public float followSpeed = 5f; // Speed at which the capsule follows
    public float slowEffect = 0.8f; // Percentage of original speed when slowed
    private float attachTime = 0f; // Time the capsule has been attached to the character
    private bool isAttached = false; // Whether the capsule is attached to the character

    private PlayerScript characterController; // Reference to the character controller script

    void Start()
    {
        // Find the character controller script on the target
        if (target != null) 
        {
            characterController = target.GetComponent<PlayerScript>();
        }
    }

    void Update()
    {
        // Make the capsule follow the character
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }

        // Handle the attachment timer
        if (isAttached)
        {
            attachTime += Time.deltaTime;
            if (attachTime >= 7f)
            {
                KillCharacter();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            // Attach to the character
            isAttached = true;
            attachTime = 0f;

            // Apply the slow effect
            if (characterController != null)
            {
                characterController.AdjustSpeed(slowEffect);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target)
        {
            // Detach from the character
            isAttached = false;
            attachTime = 0f;

            // Remove the slow effect
            if (characterController != null)
            {
                characterController.ResetSpeed();
            }
        }
    }

    private void KillCharacter()
    {
        Debug.Log("Character killed!");
        // Implement character death logic, e.g., destroy the character or trigger a death animation
        Destroy(target.gameObject);
    }
}
