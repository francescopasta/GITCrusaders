using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggerScriptWorking : MonoBehaviour
{
    public Transform target; // The object to follow and look at
    public float speed = 5f; // Speed of movement
    public bool huggedPlayer;
    public Transform parentLocation;
    public Rigidbody rb;
    void Update()
    {
        if (target != null)
        {
            // Get the position of the target
            Vector3 targetPosition = target.position;

            // Ignore the Y rotation by locking the object's Y position
            targetPosition.y = transform.position.y;

            // Make the object look at the target (only rotates around Y-axis)
            transform.LookAt(targetPosition);

            // Move the object towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
    }
    private void OnDisable()
    {
        transform.position = parentLocation.position;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }
    private void OnEnable()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
}
