using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightEnable : MonoBehaviour
{
    public GameObject parentObject;
    public Detection detection;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            parentObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detection.transform.position = detection.startPoint.position;
            detection.i = 0;
            parentObject.SetActive(false);
        }
    }
}
