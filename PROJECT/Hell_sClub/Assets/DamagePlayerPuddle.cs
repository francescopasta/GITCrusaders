using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerPuddle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerScript playerHealth = other.GetComponent<PlayerScript>();
            playerHealth.PlayerHealth--;
        }
    }
}
