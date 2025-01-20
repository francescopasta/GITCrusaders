using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HuggingPlayer : MonoBehaviour
{
    public PlayerScript playerScript;
    public List<GameObject> huggers;
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
        if (collision.gameObject.CompareTag("Hugger")) 
        {           
            if (!huggers[0].activeSelf)
            {
                huggers[0].SetActive(true);
                totalSlowDown -= slowDownToAdd;
            }
            else if (!huggers[1].activeSelf)
            {
                huggers[1].SetActive(true);
                totalSlowDown -= slowDownToAdd;
            }
            else
            {
                huggers[2].SetActive(true);
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
    }
    public IEnumerator HugPlayerToDeath() 
    {

        yield return new WaitForSeconds(dyingTimer);
        playerScript.TakeDamage(100);
        
    }
}
