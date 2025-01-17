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
    public float shakeMagnitude;   // Magnitude of the shake
    public float shakeFrequency;     // Frequency of the shake motion
    public float dampingSpeed = 1.0f;     // How quickly the shake dampens
    public float verticalShake = 0.2f;

    private float verticalRotation = 0f;  // Track vertical rotation for clamping
    private Vector3 velocity;             // Velocity for gravity application

    private Vector3 initialCameraPosition; // Store the initial position of the camera
    private float currentShakeDuration = 0f; // Remaining duration of the shake effect
    private float shakeTime = 0f;         // Time tracker for smooth shake oscillation
    private bool isShaking = false;       // Whether the shake effect is active

    public bool isAtBar = false;
    public bool isAtButter = false;
    public GameObject spacebar;

    public List<GameObject> triggersCollider;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        initialCameraPosition = cameraTransform.localPosition; // Store initial camera position
        shakeMagnitude = 1f;
        shakeFrequency = 1.6f;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && isAtBar) // Press Space to trigger the shake
        {
            TriggerCameraShake();
            spacebar.SetActive(false);
            isAtBar = false;
            foreach (GameObject obj in triggersCollider)
            {
                obj.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && isAtButter)
        {
            spacebar.SetActive(false);
            shakeFrequency = 150f;
            shakeMagnitude = 0.2f;
            verticalShake = 0.2f;
            TriggerCameraShake();
            isAtButter=false;
        }

        HandleCameraShake(); // Update the camera shake effect if active
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
        isShaking = true; // Start the shake effect
    }

    void HandleCameraShake()
    {
        if (isShaking)
        {
            if (currentShakeDuration > 0)
            {
                shakeTime += Time.deltaTime * shakeFrequency;

                // Create a smooth oscillating shake using Mathf.Sin and Mathf.Cos
                float xShake = Mathf.Sin(shakeTime) * shakeMagnitude;
                float yShake = Mathf.Cos(shakeTime) * shakeMagnitude * verticalShake; // Smaller vertical shake
                float zShake = Mathf.Sin(shakeTime * verticalShake) * shakeMagnitude * 0.5f; // Add some Z axis shake

                float rotationShake = Mathf.Sin(shakeTime) * shakeMagnitude * 2f;

                // Apply the shake as an offset from the initial camera position
                cameraTransform.localPosition = initialCameraPosition + new Vector3(xShake, yShake, zShake);
                cameraTransform.localRotation = Quaternion.Euler(verticalRotation + rotationShake, 0f, 0f);

                // Reduce shake duration
                currentShakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                // Reset shake effect when duration ends
                isShaking = false;
                cameraTransform.localPosition = initialCameraPosition;
                cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            }
        }
    }
}
