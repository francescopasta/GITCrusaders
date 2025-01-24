using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitTrigger : MonoBehaviour
{
    public GameObject vomitCameraRoot;

    private void Start()
    {
        vomitCameraRoot.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);

            vomitCameraRoot.gameObject.SetActive(true);
        }
    }
}
