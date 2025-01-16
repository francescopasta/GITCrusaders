using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HuggingPlayer : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject hugger1;
    public GameObject hugger2;
    public GameObject hugger3;
    private float totalSlowDown = 1;
    public float slowDownToAdd = 0.33f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hugger")) 
        {
            if (!hugger1.activeSelf)
            {
                hugger1.SetActive(true);
                totalSlowDown -= slowDownToAdd;
            }
            else if (!hugger2.activeSelf)
            {
                hugger2.SetActive(true);
                totalSlowDown -= slowDownToAdd;
            }
            else
            {
                hugger3.SetActive(true);
                totalSlowDown -= slowDownToAdd;
            }
            Destroy(collision.gameObject);
            playerScript.WalkSpeed *= totalSlowDown;
            playerScript.SprintSpeed *= totalSlowDown;
        }
    }
}
