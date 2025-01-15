using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cover")) 
        {
            float size = transform.position.x - other.transform.position.x;
            transform.localScale = new Vector3(transform.localScale.x, size, transform.localScale.z);

        }
    }
}
