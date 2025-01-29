using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeThing : MonoBehaviour
{
    public GameObject thing;

    private void Start()
    {
        thing.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            thing.gameObject.SetActive(false);
        }
    }
}
