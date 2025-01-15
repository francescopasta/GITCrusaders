using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaceholderScript : MonoBehaviour
{
    // Amount to change the position and rotation per second
    public float positionChangeSpeed = 1f;
    public float rotationChangeSpeed = 15f;
    public float moveSmoothness = 5f;
    public float rotateSmoothness = 5f;

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
        // Update target values if a key is held
        if (Input.GetKey(KeyCode.D))
        {
            ChangeObjectValues(Time.deltaTime * positionChangeSpeed, -Time.deltaTime * rotationChangeSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ChangeObjectValues(-Time.deltaTime * positionChangeSpeed, Time.deltaTime * rotationChangeSpeed);
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
