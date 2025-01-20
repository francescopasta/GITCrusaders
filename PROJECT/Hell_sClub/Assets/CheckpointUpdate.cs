using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    public GameMaster Master;
    private void OnTriggerEnter(Collider other)
    {
        Master.lastCheckpointLocation = transform.position;
    }
}
