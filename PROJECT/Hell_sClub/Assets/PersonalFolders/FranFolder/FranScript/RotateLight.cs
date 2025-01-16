using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>(); // List of points to rotate between
    public float rotationSpeed = 50f; // Speed of rotation in degrees per second

    private int currentPointIndex = 0; // Current index in the points list
    private bool rotatingForward = true; // Direction flag to determine whether we're rotating forward or backward

    void Start()
    {
        // Initialize the rotation to point toward the first point
        if (points.Count > 0)
        {
            Vector3 directionToFirstPoint = points[0].transform.position - transform.position;
            Quaternion initialRotation = Quaternion.LookRotation(directionToFirstPoint);
            transform.rotation = initialRotation;
        }
    }

    void Update()
    {
        if (points.Count > 0)
        {
            // Rotate the object towards the current target point
            RotateTowardsTarget();
        }
    }

    void RotateTowardsTarget()
    {
        // Get the current target point
        Transform targetPoint = points[currentPointIndex].transform;

        // Calculate the direction from the object's position to the target point
        Vector3 directionToTarget = targetPoint.position - transform.position;

        // Calculate the target rotation to face the target point
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Smoothly rotate from the current rotation to the target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the object is close enough to the target rotation
        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            // After reaching the target, switch direction
            if (rotatingForward)
            {
                currentPointIndex++; // Move to the next point in the list
                if (currentPointIndex >= points.Count) currentPointIndex = points.Count - 1; // Stay within bounds
            }
            else
            {
                currentPointIndex--; // Move to the previous point in the list
                if (currentPointIndex < 0) currentPointIndex = 0; // Stay within bounds
            }

            // Reverse the rotation direction when we reach the end or start
            rotatingForward = !rotatingForward;
        }
    }
}
