using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionActivation : MonoBehaviour
{
    public GameObject visionParent;
    public Detection detection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            visionParent.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detection.transform.position = detection.startPoint.transform.position;
            detection.i = 0;
            visionParent.SetActive(false);
        }
    }
}
