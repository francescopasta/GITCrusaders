using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FirstScene_Controller : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5f;

    public bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.01f)
            {
                shouldMove = false;
            }
        }
    }
}
