using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FirstScene_Controller : MonoBehaviour
{
    public GameObject target;
    public GameObject targetTwo;
    public float moveSpeed = 5f;

    public GameObject spacebar;
    public bool readyToHug = false;

    public bool shouldMove = false;
    public bool shouldMoveAgain = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            FirstMove();
        }

        if (shouldMoveAgain)
        {
            HugMove();
        }

        if (Input.GetKeyDown(KeyCode.Space) && readyToHug)
        {
            spacebar.SetActive(false);
            //Trigger ANIMATION
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!spacebar.activeSelf)
            {
                spacebar.SetActive(true);
            }
            readyToHug = true;
        }
    }
    private void FirstMove()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;

        //Quaternion lookRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, moveSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.01f)
        {
            shouldMove = false;
        }
    } 

    private void HugMove()
    {
        Vector3 direction = (targetTwo.transform.position - transform.position).normalized;

        //Quaternion lookRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, moveSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, targetTwo.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetTwo.transform.position) < 0.01f)
        {
            shouldMove = false;
        }
    }
}
