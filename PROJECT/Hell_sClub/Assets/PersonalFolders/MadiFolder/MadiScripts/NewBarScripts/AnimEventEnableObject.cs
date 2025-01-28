using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventEnableObject : MonoBehaviour
{
    public GameObject objectToTurnOn;

    // This function will be called by the Animation Event
    public void TurnOnObject()
    {
        if (objectToTurnOn != null)
        {
            objectToTurnOn.SetActive(true);
        }
    }
}
