using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSquareRestriction : MonoBehaviour
{
    public Transform player; // Reference to the player (for horizontal rotation)
    public float minVerticalAngle = -45f; // Minimum vertical angle (pitch)
    public float maxVerticalAngle = 45f; // Maximum vertical angle (pitch)
    public float minHorizontalAngle = -90f; // Minimum horizontal angle (yaw, relative to starting position)
    public float maxHorizontalAngle = 90f; // Maximum horizontal angle (yaw, relative to starting position)
    public float rotationSpeed = 100f; // Sensitivity for camera rotation

    private float verticalRotation = 0f; // Tracks the vertical rotation angle
    private float horizontalRotation = 0f; // Tracks the horizontal rotation angle (relative to the initial position)

    void Start()
    {
        // Initialize horizontal rotation based on the player's initial rotation
        horizontalRotation = player.eulerAngles.y;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Calculate horizontal rotation
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle, maxHorizontalAngle);

        // Apply horizontal rotation to the player
        player.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        // Calculate vertical rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // Apply vertical rotation to the camera (local rotation)
        transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }
}
