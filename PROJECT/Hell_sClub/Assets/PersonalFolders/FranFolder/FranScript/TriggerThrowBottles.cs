using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThrowBottles : MonoBehaviour
{
    public GameObject throwingObject;
    public List<GameObject> bottleObjects;
    private int count;
    private void OnTriggerEnter(Collider other)
    {
        throwingObject.SetActive(true);
        foreach (GameObject bottle in bottleObjects)
        {
            if (bottle.activeSelf && bottle != throwingObject)
            {
                bottle.SetActive(false);
            }
        }
      
    }
}
