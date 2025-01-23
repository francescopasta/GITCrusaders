using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggerPlayerDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                HuggerScriptWorking hugger = child.GetComponent<HuggerScriptWorking>();
                hugger.target = other.transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                HuggerScriptWorking hugger = child.GetComponent<HuggerScriptWorking>();
                hugger.target = null;
               
            }
        }
    }
}
