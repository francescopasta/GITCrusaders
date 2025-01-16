using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingLight : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Destroy(player);
        }
    }
}
