using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventDisableObj : MonoBehaviour
{
    public GameObject objectToTurnOff;

    // This function will be called by the Animation Event
    public void TurnOffObject()
    {
        if (objectToTurnOff != null)
        {
            objectToTurnOff.SetActive(false);
        }
    }
}
