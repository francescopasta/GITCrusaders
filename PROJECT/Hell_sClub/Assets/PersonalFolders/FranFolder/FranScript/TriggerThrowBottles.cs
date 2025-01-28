using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThrowBottles : MonoBehaviour
{
    public GameObject throwingObject;
    public GameObject previousThrowingObject;
    private int count;
    private void OnTriggerEnter(Collider other)
    {
        throwingObject.SetActive(true);
        if (previousThrowingObject != null)
        {
            previousThrowingObject.SetActive(false);
        }
    }
}
