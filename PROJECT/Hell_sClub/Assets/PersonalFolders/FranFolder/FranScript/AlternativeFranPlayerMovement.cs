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

    public float shakeDuration = 0.5f;     // How long the camera should shake
    public float shakeMagnitude = 0.2f;   // Magnitude of the shake
    public float shakeFrequency = 2f;     // Frequency of the shake motion
    public float dampingSpeed = 1.0f;     // How quickly the shake dampens

    private float verticalRotation = 0f;  // Track vertical rotation for clamping
    private Vector3 velocity;             // Velocity for gravity application

    private Vector3 initialCameraPosition; // Store the initial position of the camera
    private float currentShakeDuration = 0f; // Remaining duration of the shake effect
    private float shakeTime = 0f;         // Time tracker for smooth shake oscillation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        initialCameraPosition = cameraTransform.localPosition; // Store initial camera position
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleCameraShake(); // Update the camera shake effect if active
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to trigger the shake
        {
            TriggerCameraShake();
        }
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

    public void TriggerCameraShake()
    {
        currentShakeDuration = shakeDuration; // Reset the shake duration
        shakeTime = 0f; // Reset the oscillation time
    }

    void HandleCameraShake()
    {
        if (currentShakeDuration > 0)
        {
            shakeTime += Time.deltaTime * shakeFrequency;

            // Create a smooth oscillating shake using Mathf.Sin and Mathf.Cos
            float xShake = Mathf.Sin(shakeTime) * shakeMagnitude;
            float yShake = Mathf.Cos(shakeTime) * shakeMagnitude * 0.5f; // Smaller vertical shake
            float zShake = Mathf.Sin(shakeTime * 0.5f) * shakeMagnitude * 0.3f; // Add some Z axis shake

            // Apply the shake to the camera's local position
            cameraTransform.localPosition = initialCameraPosition + new Vector3(xShake, yShake, zShake);

            // Reduce shake duration
            currentShakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else if (cameraTransform.localPosition != initialCameraPosition)
        {
            // Reset camera position after shake ends
            cameraTransform.localPosition = initialCameraPosition;
        }
    }
}
