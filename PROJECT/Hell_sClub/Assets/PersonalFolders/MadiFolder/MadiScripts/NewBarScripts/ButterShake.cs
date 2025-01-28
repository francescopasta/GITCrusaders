using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterShake : MonoBehaviour
{
    public float moveDistance = 10f; // How far the camera moves
    public float moveSpeed = 2f; // Speed at which the camera moves

    private float startPosition;

    void Start()
    {
        // Save the camera's initial position
        startPosition = transform.position.x;
    }

    void Update()
    {
        // Calculate the movement along the x-axis
        float moveAmount = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // Apply the movement
        transform.position = new Vector3(startPosition + moveAmount, transform.position.y, transform.position.z);
    }
}
