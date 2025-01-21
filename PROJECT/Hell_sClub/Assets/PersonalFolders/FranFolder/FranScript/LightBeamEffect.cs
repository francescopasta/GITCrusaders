using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamEffect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other != null)
            {
                PlayerScript playerScript = other.GetComponent<PlayerScript>();
                if (playerScript != null)
                {
                    playerScript.TakeDamage(100f);
                }
            }
        }
    }
}
