using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThrowBottles : MonoBehaviour
{
    public ThrowFromPoint bottle;
    private int count;
    private void OnTriggerEnter(Collider other)
    {
        if(count == 0)
        {
            bottle.Throw();
        }
        count++;
    }
}
