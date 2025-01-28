using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabkeScript : MonoBehaviour
{
    public Camera targetCamera;             // The camera to target
    public ButterShake butterShakeScript;   // Reference to the ButterShake script

    // This method will be called by the animation event
    public void EnableButterShakeScript()
    {
        if (targetCamera != null && butterShakeScript != null)
        {
            // Enable or disable the ButterShake script on the assigned camera
            butterShakeScript.enabled = true;
            Debug.Log("ButterShake script enabled!");
        }
        else
        {
            if (targetCamera == null)
                Debug.LogWarning("Target camera is not assigned.");
            if (butterShakeScript == null)
                Debug.LogWarning("ButterShake script is not assigned.");
        }
    }

    // Optionally, you can disable the script later if needed
    public void DisableButterShakeScript()
    {
        if (butterShakeScript != null)
        {
            butterShakeScript.enabled = false;
            Debug.Log("ButterShake script disabled!");
        }
    }
}
