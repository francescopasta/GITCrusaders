using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeFranPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    [Header("Player Values")]
    [Space(10)]
    public float walkSpeed = 12f;
    public float sprintSpeed = 24f;
    public float mouseSensitivity = 100f;
    public float gravity = -9.81f;

    private float shakeDuration = 0.5f;
    private float shakeMagnitude;
    private float shakeFrequency;
    private float dampingSpeed = 1.0f;
    private float verticalShake = 0.2f;
    private float shakeDepth = 0.4f;

    private float verticalRotation = 0f;
    private Vector3 velocity;

    private Vector3 initialCameraPosition;
    private float currentShakeDuration = 0f;
    private float shakeTime = 0f;
    private bool isShaking = false;

    [Header("Booleans")]
    [Space(10)]
    public bool isAtBar = false;
    public bool isAtButter = false;

    [Header("UI")]
    [Space(10)]
    public GameObject SpacebarUI;

    [Header("Triggers List")]
    [Space(10)]
    public List<GameObject> triggersCollider;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        initialCameraPosition = cameraTransform.localPosition; // Store initial camera position
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && isAtBar) // Press Space to trigger (weak) shake
        {
            TriggerCameraShake();
            SpacebarUI.SetActive(false);
            isAtBar = false;
            foreach (GameObject obj in triggersCollider)
            {
                obj.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isAtButter) // Press Space to trigger (strong) shake
        {
            SpacebarUI.SetActive(false);
            shakeFrequency = 150f;
            shakeMagnitude = 0.2f;
            verticalShake = 0.2f;
            TriggerCameraShake();
            isAtButter = false;
        }

        HandleCameraShake();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically and clamp it to prevent over-rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); // Apply the rotation separately
    }

    void HandleMovement()
    {
        // Get movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

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
        shakeTime = 0f; // Reset the cycle time
        isShaking = true;
    }

    void HandleCameraShake()
    {
        if (isShaking)
        {
            if (currentShakeDuration > 0)
            {
                shakeTime += Time.deltaTime * shakeFrequency;

                // Create a smooth shake
                float xShake = Mathf.Sin(shakeTime) * shakeMagnitude; // X axis shake
                float yShake = Mathf.Cos(shakeTime) * shakeMagnitude * verticalShake; // Y axis shake
                float zShake = Mathf.Sin(shakeTime * shakeDepth) * shakeMagnitude * 0.5f; // Z axis shake

                // Apply the shake only on the localPosition, not affecting rotation
                cameraTransform.localPosition = initialCameraPosition + new Vector3(xShake, yShake, zShake);

                // Count down shake duration
                currentShakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                // Reset shake effect when duration ends
                isShaking = false;
                cameraTransform.localPosition = initialCameraPosition;
            }
        }
    }
}
