using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingDrink : MonoBehaviour
{
    public NPC_FirstScene_Controller npcController;
    public AlternativeFranPlayerMovement playerController;
    public GameObject spacebar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcController.shouldMove = true;
            playerController.isAtBar = true;
            spacebar.SetActive(true);
        }
    }
}
