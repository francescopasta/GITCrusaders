using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerPuddle : MonoBehaviour
{
    public bool dealingDamage = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript playerScript = other.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                if (!dealingDamage)
                {
                    StartCoroutine(PoolDamage(playerScript));
                }
            }
        }
    }
    public IEnumerator PoolDamage(PlayerScript playerScript) 
    {
        dealingDamage = true;
        yield return new WaitForSeconds(1f);
        playerScript.PlayerHealth -= 5;
        yield return new WaitForSeconds(1f);
        dealingDamage = false;

    }
}
