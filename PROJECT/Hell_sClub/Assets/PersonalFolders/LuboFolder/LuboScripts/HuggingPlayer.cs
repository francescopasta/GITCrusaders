using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HuggingPlayer : MonoBehaviour
{
    public PlayerScript playerScript;
    //huggers
    public List<GameObject> huggers;
    public List<GameObject> huggerParents;
    private float totalSlowDown = 1;
    public float slowDownToAdd = 0.33f;
    public float dyingTimer = 2f;
    public float deactivationTimer = 1f;
    public float ogMovementWalking;
    public float ogMovementRunning;

    private void Start()
    {
        ogMovementWalking = playerScript.WalkSpeed; 
        ogMovementRunning = playerScript.SprintSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hugger") && playerScript.Grounded) 
        {           
            if (!huggers[0].activeSelf)
            {
                huggers[0].SetActive(true);
                Rigidbody rb = huggers[0].GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                rb.mass = 0;
                huggers[0].transform.position = huggerParents[0].transform.position;
                huggers[0].transform.rotation = huggerParents[0].transform.rotation;
                totalSlowDown -= slowDownToAdd;
            }
            else if (!huggers[1].activeSelf)
            {
                huggers[1].SetActive(true);
                Rigidbody rb = huggers[1].GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                rb.mass = 0;
                huggers[1].transform.position = huggerParents[1].transform.position;
                huggers[1].transform.rotation = huggerParents[1].transform.rotation;
                totalSlowDown -= slowDownToAdd;
            }
            else
            {
                huggers[2].SetActive(true);
                Rigidbody rb = huggers[2].GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                rb.mass = 0;
                huggers[2].transform.position = huggerParents[2].transform.position;
                huggers[2].transform.rotation = huggerParents[2].transform.rotation;
                totalSlowDown -= slowDownToAdd;
            }
            if (huggers[0].activeSelf && huggers[1].activeSelf && huggers[2].activeSelf)
            {
                StartCoroutine(HugPlayerToDeath());
            }
            Destroy(collision.gameObject);
            playerScript.WalkSpeed *= totalSlowDown;
            playerScript.SprintSpeed *= totalSlowDown;
        }
    }
    public IEnumerator DeactivateEnemies() 
    {
        yield return new WaitForSeconds(deactivationTimer);
        foreach (var item in huggers)
        {
            item.gameObject.SetActive(false);
        }
        playerScript.WalkSpeed = ogMovementWalking;
        playerScript.SprintSpeed = ogMovementRunning;
        totalSlowDown = 1f;
    }
    public IEnumerator HugPlayerToDeath() 
    {

        yield return new WaitForSeconds(dyingTimer);
        if (huggers[0].activeSelf && huggers[1].activeSelf && huggers[2].activeSelf)
        {
            playerScript.TakeDamage(100);

        }
        else
        {
            yield return null;
        }
    }
}
