using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionDamage : MonoBehaviour
{
    public Vector3 originalScale;
    private void Start()
    {
        originalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cover")) 
        {
            float size = transform.position.x - other.transform.position.x;
            transform.localScale = new Vector3(transform.localScale.x, size, transform.localScale.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cover"))
        {
            transform.localScale = originalScale;
        }
    }

}
