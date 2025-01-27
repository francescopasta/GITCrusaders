using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamEffect : MonoBehaviour
{
    public PlayerScript playerScript;
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
        else if (other.CompareTag("Hugger"))
        {
            if (other != null)
            {
                playerScript.disabledEnemies.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
    }
}
