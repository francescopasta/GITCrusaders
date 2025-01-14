using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBreak : MonoBehaviour
{
    public GameObject juicePool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(juicePool, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
