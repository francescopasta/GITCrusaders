using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HuggingPlayer : MonoBehaviour
{
    public PlayerScript playerScript;
    public pushMechanic pushMechanic;
    //huggers
    public List<GameObject> huggerList;
    public List<GameObject> huggerParents;
    public int attachedHuggers = 0;
    //slowDownAndDestroy
    private float totalSlowDown = 1;
    public float slowDownToAdd = 0.33f;
    public float dyingTimer = 2f;
    public float deactivationTimer = 1f;
    public float timer = 0f;
    //ogValues
    public float ogMovementWalking;
    public float ogMovementRunning;
    
    //Damage
    [SerializeField]private float totalDamage;
    public float damageToAdd;
    public float damageTickTimer;
    [SerializeField] private bool damagingPlayer;

    public AudioSource audioSource;
    private void Start()
    {
        ogMovementWalking = playerScript.WalkSpeed; 
        ogMovementRunning = playerScript.SprintSpeed;
    }
    public void FixedUpdate()
    {
        if (!damagingPlayer && attachedHuggers > 0)
        {
            StartCoroutine(DamagePlayer());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hugger") && playerScript.Grounded) 
        {
            audioSource.Play();
            playerScript.disabledEnemies.Add(collision.gameObject);
            if (!huggerList[0].activeSelf)
            {
                huggerList[0].SetActive(true);
                collision.gameObject.SetActive(false);
                Rigidbody rb = huggerList[0].gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                huggerList[0].transform.rotation = huggerParents[0].transform.rotation;
                rb.mass = 0;
                huggerList[0].transform.position = huggerParents[0].transform.position;
                DecreaseSpeed();
                attachedHuggers++;
                pushMechanic.totalMashRequirement += 5;
                totalDamage += damageToAdd;
            }
            else if (!huggerList[1].activeSelf)
            {
                huggerList[1].SetActive(true);;
                collision.gameObject.SetActive(false);
                Rigidbody rb = huggerList[1].gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                huggerList[1].transform.rotation = huggerParents[1].transform.rotation;
                rb.mass = 0;
                huggerList[1].transform.position = huggerParents[1].transform.position;
                DecreaseSpeed();
                attachedHuggers++;
                pushMechanic.totalMashRequirement += 5;
                totalDamage += damageToAdd;
            }
            else
            {
                huggerList[2].SetActive(true);
                collision.gameObject.SetActive(false);
                Rigidbody rb = huggerList[2].gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                huggerList[2].transform.rotation = huggerParents[2].transform.rotation;
                rb.mass = 0;
                huggerList[2].transform.position = huggerParents[2].transform.position;
                DecreaseSpeed();
                attachedHuggers++;
                pushMechanic.totalMashRequirement += 5;
                totalDamage += damageToAdd;

            }
            if (huggerList[0].activeSelf && huggerList[1].activeSelf && huggerList[2].activeSelf)
            {
                StartCoroutine(HugPlayerToDeath());
            }
        }
    }
    public void ResetSpeed()
    {
        totalSlowDown = 1;
        playerScript.WalkSpeed = ogMovementWalking;
        playerScript.SprintSpeed = ogMovementRunning;
        totalSlowDown = 1f;
    }
    public void DeactivateEnemies(float deactivationTimer) 
    {
        timer = 0f;
        // return new WaitForSeconds(deactivationTimer);
        while (timer < deactivationTimer)
        {
            timer += Time.deltaTime;
        }
        for (int i = 0; i < huggerList.Count-1; i++)
        {
            huggerList[i].transform.position = huggerParents[i].transform.position;
        }
        foreach (var item in huggerList)
        {
            item.gameObject.SetActive(false);
        }
        attachedHuggers = 0;
        pushMechanic.totalMashRequirement = 0;
        totalDamage = 0;
        damagingPlayer = false;
        ResetSpeed();
    }
    public IEnumerator DamagePlayer() 
    {
        damagingPlayer = true;
        yield return new WaitForSeconds(damageTickTimer);
        playerScript.TakeDamage(totalDamage);
        damagingPlayer =false;
    }
    public IEnumerator HugPlayerToDeath() 
    {

        yield return new WaitForSeconds(dyingTimer);
        if (huggerList[0].activeSelf && huggerList[1].activeSelf && huggerList[2].activeSelf)
        {
            playerScript.TakeDamage(100);
            DeactivateEnemies(0);

        }
        else
        {
            yield return null;
        }
    }
    public void DecreaseSpeed()
    {
        totalSlowDown -= slowDownToAdd;
        playerScript.WalkSpeed *= slowDownToAdd;
        playerScript.SprintSpeed *= slowDownToAdd;
    }
}
//BACKUP


//if (!huggers[0].activeSelf)
//{
//    huggers[0].SetActive(true);
//    Rigidbody rb = huggers[0].GetComponent<Rigidbody>();
//    rb.constraints = RigidbodyConstraints.FreezeAll;
//    rb.useGravity = false;
//    rb.mass = 0;
//    huggers[0].transform.position = huggerParents[0].transform.position;
//    huggers[0].transform.rotation = huggerParents[0].transform.rotation;
//    totalSlowDown -= slowDownToAdd;
//}
//else if (!huggers[1].activeSelf)
//{
//    huggers[1].SetActive(true);
//    Rigidbody rb = huggers[1].GetComponent<Rigidbody>();
//    rb.constraints = RigidbodyConstraints.FreezeAll;
//    rb.useGravity = false;
//    rb.mass = 0;
//    huggers[1].transform.position = huggerParents[1].transform.position;
//    huggers[1].transform.rotation = huggerParents[1].transform.rotation;
//    totalSlowDown -= slowDownToAdd;
//}
//else
//{
//    huggers[2].SetActive(true);
//    Rigidbody rb = huggers[2].GetComponent<Rigidbody>();
//    rb.constraints = RigidbodyConstraints.FreezeAll;
//    rb.useGravity = false;
//    rb.mass = 0;
//    huggers[2].transform.position = huggerParents[2].transform.position;
//    huggers[2].transform.rotation = huggerParents[2].transform.rotation;
//    totalSlowDown -= slowDownToAdd;
//}
//if (huggers[0].activeSelf && huggers[1].activeSelf && huggers[2].activeSelf)
//{
//    StartCoroutine(HugPlayerToDeath());
//}
//Destroy(collision.gameObject);
//playerScript.WalkSpeed *= totalSlowDown;
//playerScript.SprintSpeed *= totalSlowDown;