using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingLight : MonoBehaviour
{
    public GameObject lightCollider; 
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cover"))
        {
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
