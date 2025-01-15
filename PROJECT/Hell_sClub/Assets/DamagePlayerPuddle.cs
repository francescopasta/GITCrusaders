using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePlayerPuddle : MonoBehaviour
{
    public bool dealingDamage = false;
    public float coolDown = 1f;
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
        yield return new WaitForSeconds(coolDown);
        playerScript.PlayerHealth -= 5;
        yield return new WaitForSeconds(coolDown);
        dealingDamage = false;

    }
}
