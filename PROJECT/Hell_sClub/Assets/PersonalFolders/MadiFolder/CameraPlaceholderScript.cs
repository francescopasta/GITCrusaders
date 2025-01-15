using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaceholderScript : MonoBehaviour
{
    // Player reference
    public Transform player;

    // Rotation change settings
    public float rotationChangeSpeed = 15f;
    public float shiftMultiplier = 1.25f;
    public float moveSmoothness = 5f;
    public float rotateSmoothness = 5f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        // Initialize target position and rotation with the current values
        targetPosition = transform.position;
        targetRotation = transform.rotation;

        // Ensure player is assigned
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned! Please assign it in the Inspector.");
        }
    }

    void Update()
    {
        if (player == null)
            return; // Exit if no player is assigned

        // Get the player's current Y position
        float playerY = player.position.y;

        // Compute the position change speed based on the player's Y position
        float positionChangeSpeed = Mathf.Abs(playerY) * 0.1f; // Adjust multiplier for scaling

        // Determine if the shift key is held
        float multiplier = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? shiftMultiplier : 1f;

        // Update target values if a key is held
        if (Input.GetKey(KeyCode.D))
        {
            ChangeObjectValues(Time.deltaTime * positionChangeSpeed * multiplier, -Time.deltaTime * rotationChangeSpeed * multiplier);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ChangeObjectValues(-Time.deltaTime * positionChangeSpeed * multiplier, Time.deltaTime * rotationChangeSpeed * multiplier);
        }

        // Smoothly move towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSmoothness);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSmoothness);
    }

    // Function to update the target position and rotation
    void ChangeObjectValues(float positionDelta, float rotationDelta)
    {
        // Update the target position
        targetPosition += new Vector3(0, positionDelta, 0);

        // Update the target rotation
        targetRotation = Quaternion.Euler(
            targetRotation.eulerAngles.x,
            targetRotation.eulerAngles.y + rotationDelta,
            targetRotation.eulerAngles.z
        );
    }
}
