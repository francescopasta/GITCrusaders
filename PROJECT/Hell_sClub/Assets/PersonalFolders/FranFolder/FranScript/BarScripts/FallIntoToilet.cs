using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FallIntoToilet : MonoBehaviour
{
    public GameObject player;
    public AlternativeFranPlayerMovement playerScript;
    public GameObject target;
    public float moveSpeed = 0.01f;

    private GameObject fallCamera;

    private void Start()
    {
        playerScript = player.GetComponent<AlternativeFranPlayerMovement>();
        fallCamera = playerScript.cameraTransform.transform.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        fallCamera.transform.GetComponent<Collider>().enabled = false;

        player.transform.GetComponent<Collider>().enabled = false;

        playerScript.enabled = false;

        //Vector3 direction = (target.transform.position - transform.position).normalized;

        //Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        //player.transform.SetPositionAndRotation(Vector3.MoveTowards(target.transform.position, target.transform.position, moveSpeed * Time.deltaTime), Quaternion.Slerp(transform.rotation, lookRotation, moveSpeed * Time.deltaTime));

        player.transform.position = Vector3.MoveTowards(target.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}
