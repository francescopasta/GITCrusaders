using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToEdgeOnTrigger : MonoBehaviour
{
    public List<Transform> points = new List<Transform>(); // Points to move between
    public float speed = 0.3f; // Movement speed
    public int i = 0; // Current target index
    private Vector3 direction; // Movement direction
    private CapsuleCollider capsuleCollider; // Reference to the CapsuleCollider
    private Vector3 capsuleTopOffset; // Offset to the top of the capsule

    private void Start()
    {
        // Get the CapsuleCollider component and calculate the top offset
        capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            capsuleTopOffset = new Vector3(0, capsuleCollider.height / 2, 0);
        }
        else
        {
            Debug.LogError("CapsuleCollider not found on the GameObject!");
        }
    }

    private void FixedUpdate()
    {
        if (points.Count == 0 || capsuleCollider == null) return; // Exit if no points or no collider

        // Calculate the top of the capsule's position
        Vector3 capsuleTop = transform.position + transform.rotation * capsuleTopOffset;

        // Calculate the direction towards the target point
        direction = (points[i].position - capsuleTop).normalized;

        // Move the capsule top towards the target
        transform.position += direction * speed;

        // Check if the top of the capsule has reached the target point
        if (Vector3.Distance(capsuleTop, points[i].position) < 0.1f)
        {
            i = (i + 1) % points.Count; // Move to the next point
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the points and capsule top in the editor
        Gizmos.color = Color.green;
        foreach (var point in points)
        {
            if (point != null)
                Gizmos.DrawSphere(point.position, 0.1f);
        }

        if (capsuleCollider != null)
        {
            Vector3 capsuleTop = transform.position + transform.rotation * capsuleTopOffset;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(capsuleTop, 0.1f);
        }
    }
}
