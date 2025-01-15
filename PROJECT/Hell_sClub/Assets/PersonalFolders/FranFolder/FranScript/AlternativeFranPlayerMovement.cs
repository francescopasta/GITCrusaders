using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeFranPlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Attach the CharacterController component
    public Transform cameraTransform;      // Reference to the camera attached to the player

    public float walkSpeed = 12f;           // Normal walking speed
    public float sprintSpeed = 24f;        // Sprinting speed
    public float mouseSensitivity = 100f; // Sensitivity of mouse for looking around
    public float gravity = -9.81f;        // Gravity applied to the player

    private float verticalRotation = 0f;  // Track vertical rotation for clamping
    private Vector3 velocity;             // Velocity for gravity application

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically and clamp it
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Prevent over-rotation
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        // Get movement input
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Check if Sprint key is held down
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        // Move the character
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Apply gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset gravity when grounded
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
