using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoorsTrigger : MonoBehaviour
{
    public GameObject object1; // First object to rotate
    public GameObject object2; // Second object to rotate
    public float targetRotation1 = 90f; // Desired Y rotation for object1
    public float targetRotation2 = 180f; // Desired Y rotation for object2

    // This method is called when a trigger collision happens
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Or use any other condition you need
        {
            // Change the Y rotation of both objects to the desired values
            if (object1 != null)
            {
                object1.transform.rotation = Quaternion.Euler(0f, targetRotation1, 0f);
            }

            if (object2 != null)
            {
                object2.transform.rotation = Quaternion.Euler(0f, targetRotation2, 0f);
            }
        }
    }
}
