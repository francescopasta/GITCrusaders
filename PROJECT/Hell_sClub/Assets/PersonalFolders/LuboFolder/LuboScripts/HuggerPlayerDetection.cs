using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggerPlayerDetection : MonoBehaviour
{
    public List<GameObject> HuggersInArea;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            foreach (GameObject child in HuggersInArea)
            {
                HuggerScriptWorking hugger = child.GetComponent<HuggerScriptWorking>();
                if (hugger != null)
                {
                    hugger.target = other.transform;

                }
                else
                {
                    Debug.Log("Go fuck yourself");
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject child in HuggersInArea)
            {
                HuggerScriptWorking hugger = child.GetComponent<HuggerScriptWorking>();
                if (hugger != null)
                {
                    hugger.target = null;

                }
                else
                {
                    Debug.Log("Go fuck yourself");
                }
            }
        }
    }
}

