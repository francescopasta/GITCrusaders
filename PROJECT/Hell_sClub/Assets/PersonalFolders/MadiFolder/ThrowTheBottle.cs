using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public GameObject itemPrefab;  // Prefab of the item to throw
    public Transform throwTarget;  // Empty object representing the target point
    public float throwAngle = 45f; // Angle at which to throw the item
    public float throwForce = 10f; // Initial force to apply to the item

    public void Throw()
    {
        // Instantiate the item prefab
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);

        // Calculate the direction towards the throw target
        Vector3 targetDir = throwTarget.position - transform.position;

        // Calculate the distance to the target along the horizontal plane
        float distance = Mathf.Sqrt(targetDir.x * targetDir.x + targetDir.z * targetDir.z);

        // Calculate the initial velocity needed to reach the target at the desired angle
        float initialVelocity = distance / (Mathf.Cos(throwAngle * Mathf.Deg2Rad) * Mathf.Sqrt(2 * (distance * Mathf.Tan(throwAngle * Mathf.Deg2Rad) - targetDir.y)));

        // Calculate the direction vector
        Vector3 throwVelocity = new Vector3(targetDir.x, initialVelocity * Mathf.Sin(throwAngle * Mathf.Deg2Rad), targetDir.z).normalized;

        // Apply the force to the item in the calculated direction
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = throwVelocity * throwForce;
        }
    }
}
