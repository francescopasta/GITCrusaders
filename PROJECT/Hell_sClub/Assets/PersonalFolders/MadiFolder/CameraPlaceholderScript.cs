using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaceholderScript : MonoBehaviour
{
    // Player reference
    public Transform player;

    // Rotation change settings
    public float rotationChangeSpeed = 15f; // Speed of rotation
    public float shiftMultiplier = 1.25f; // Multiplier when holding shift
    public float moveSmoothness = 5f; // Smoothness of movement
    public float rotateSmoothness = 5f; // Smoothness of rotation

    // Adjustable initial rotation offset
    [Header("Camera Rotation Settings")]
    public float initialRotationOffset = 45f; // Initial camera rotation offset to the right (in degrees), adjustable in the Inspector

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        // Initialize target position and rotation with the current values
        targetPosition = transform.position;

        // Apply the initial rotation offset of +45 degrees on the Y-axis (adjustable from Inspector)
        targetRotation = Quaternion.Euler(0, initialRotationOffset, 0);
        transform.rotation = targetRotation;  // Set the initial rotation right away

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

        // Smoothly adjust the Y position of the camera based on the player's Y position
        targetPosition.y = Mathf.Lerp(targetPosition.y, playerY + 35f, Time.deltaTime * moveSmoothness);

        // Determine if the shift key is held
        float multiplier = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? shiftMultiplier : 1f;

        // Update target values if a key is held (adjust horizontal position and rotation)
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

        // Smoothly rotate the camera based on the player's X position (left or right)
        RotateCameraBasedOnPlayerPosition();
    }

    // Function to update the target position and rotation
    void ChangeObjectValues(float positionDelta, float rotationDelta)
    {
        // Update the target position
        targetPosition += new Vector3(0, positionDelta, 0);

        // Update the target rotation (rotationDelta is the horizontal rotation change)
        targetRotation = Quaternion.Euler(
            targetRotation.eulerAngles.x,
            targetRotation.eulerAngles.y + rotationDelta,
            targetRotation.eulerAngles.z
        );
    }

    // Function to rotate the camera based on the player's position (left or right)
    void RotateCameraBasedOnPlayerPosition()
    {
        // Calculate the direction the camera should face based on the player's X position relative to the camera
        float angleToPlayer = Mathf.Atan2(player.position.x - transform.position.x, player.position.z - transform.position.z) * Mathf.Rad2Deg;

        // Smoothly rotate the camera towards the player along the Y axis
        Quaternion targetRotation = Quaternion.Euler(0, angleToPlayer + initialRotationOffset, 0);  // Add the offset
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSmoothness);
    }
}
