using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaceholderScript : MonoBehaviour
{
    // Amount to change the position and rotation
    public float positionChange = 1f;
    public float rotationChange = 15f;
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        // Initialize target position and rotation with the current values
        targetPosition = transform.position;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the D key is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeObjectValues(positionChange, -rotationChange);
        }

        // Check if the A key is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeObjectValues(-positionChange, rotationChange);
        }

        // Smoothly move towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
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
