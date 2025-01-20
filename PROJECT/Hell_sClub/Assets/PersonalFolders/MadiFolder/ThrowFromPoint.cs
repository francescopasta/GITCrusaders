using UnityEngine;

public class ThrowFromPoint : MonoBehaviour
{
    public GameObject itemPrefab;  // Prefab of the item to throw
    public Transform throwTarget; // Point to throw towards
    public float throwForce = 10f; // Strength of the throw

    //private void Update()
    //{
    //    // Check if the E key is pressed
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Throw();
    //    }
    //}

    public void Throw()
    {
        // Ensure the prefab and target are set
        if (itemPrefab == null || throwTarget == null)
        {
            Debug.LogWarning("Item prefab or throw target is not set.");
            return;
        }

        // Instantiate the item at this object's position
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);

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
    }
}
