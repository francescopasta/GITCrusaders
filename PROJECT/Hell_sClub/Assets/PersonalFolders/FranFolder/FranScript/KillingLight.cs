using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverCheck : MonoBehaviour
{
    public GameObject lightCollider; // Reference to the lightCollider object

    // List to track colliders currently overlapping
    //private List<Collider> overlappingCovers = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cover"))
        {
            //// Add the collider to the list if it's not already there
            //if (!overlappingCovers.Contains(other))
            //{
            //    overlappingCovers.Add(other);
            //}

            // Disable lightCollider since we're under cover
            lightCollider.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cover"))
        {
            
                lightCollider.SetActive(true);
           
        }
    }
}
