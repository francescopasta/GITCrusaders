using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTransition : MonoBehaviour
{
    public GameObject lightToDisable;
    public GameObject lightToEnable;
    public GameObject wallToEnable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            lightToDisable.SetActive(false);
            lightToEnable.SetActive(true);
            wallToEnable.SetActive(true);
        }
    }
}
