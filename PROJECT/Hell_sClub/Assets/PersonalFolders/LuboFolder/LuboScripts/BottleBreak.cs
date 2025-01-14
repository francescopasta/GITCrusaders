using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBreak : MonoBehaviour
{
    public GameObject juicePool;
    public int damage = 20;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerScript playerHp = collision.gameObject.GetComponent<PlayerScript>();
            playerHp.PlayerHealth -= damage;
            Instantiate(juicePool,
                new Vector3(collision.transform.position.x,
                playerHp.CheckNearestGround(),
                collision.transform.position.z),
                Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(juicePool, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
