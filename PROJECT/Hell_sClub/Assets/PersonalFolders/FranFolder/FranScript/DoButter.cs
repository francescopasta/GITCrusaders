using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoButter : MonoBehaviour
{
    public AlternativeFranPlayerMovement cameraShake;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraShake.spacebar.SetActive(true);
            cameraShake.isAtButter = true;
        }
    }
}
