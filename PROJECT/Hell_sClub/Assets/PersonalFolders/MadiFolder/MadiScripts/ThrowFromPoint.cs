using System.Collections;
using UnityEngine;

public class ThrowFromPoint : MonoBehaviour
{
    public GameObject itemPrefab;  // Prefab of the item to throw
    public Transform throwTarget; // Point to throw towards
    public float throwForce = 10f; // Strength of the throw
    public bool throwingBottles = false;
    public float throwCooldown = 1f;
    public AudioSource bottleSFX;
    private void OnEnable()
    {
        throwingBottles = false;    
    }
    private void Update()
    {
        if (!throwingBottles)
        {
            StartCoroutine(Throw());
        }
    }

    public IEnumerator Throw()
    {
        // Ensure the prefab and target are set
        if (itemPrefab == null || throwTarget == null)
        {
            Debug.LogWarning("Item prefab or throw target is not set.");
            yield return false;
        }
        throwingBottles = true;
        // Instantiate the item at this object's position
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        BottleBreak bottleBreak =  item.GetComponent<BottleBreak>();
        bottleBreak.audioClip = bottleSFX;
        // Calculate the direction from this object to the throw target
        Vector3 direction = (throwTarget.position - transform.position).normalized;

        // Apply the force to the item's Rigidbody
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * throwForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody found on the item prefab.");
        }
        yield return new WaitForSeconds(throwCooldown);
        throwingBottles = false;
    }
}
