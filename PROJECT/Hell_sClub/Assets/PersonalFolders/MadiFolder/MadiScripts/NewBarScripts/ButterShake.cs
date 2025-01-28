using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterShake : MonoBehaviour
{
    public float moveDistance = 10f; // How far the camera moves
    public float moveSpeed = 2f; // Speed at which the camera moves

    private Vector3 initialPosition; // Initial position of the camera
    private Transform cameraTransform;

    void Start()
    {
        // Get the camera's transform (ensure it’s the main camera)
        cameraTransform = Camera.main.transform;
        initialPosition = cameraTransform.localPosition; // Store initial camera position
    }

    void Update()
    {
        // If the shake is triggered (by spacebar in this case), apply the shake
        float moveAmount = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        cameraTransform.localPosition = initialPosition + new Vector3(moveAmount, 0f, 0f); // Shake only on the X-axis
    }
}
