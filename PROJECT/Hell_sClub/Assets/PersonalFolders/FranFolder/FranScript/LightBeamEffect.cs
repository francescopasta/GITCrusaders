using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamEffect : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null)
            {
                Destroy(player);
            }
        }
    }
}
