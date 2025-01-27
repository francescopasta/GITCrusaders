using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHugged : MonoBehaviour
{
    public NPC_FirstScene_Controller npcController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcController.shouldMoveAgain = true;
        }
    }
}
