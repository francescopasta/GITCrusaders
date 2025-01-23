using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCHeck : MonoBehaviour
{
    public bool grounded;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    
}
}
