using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossItem : MonoBehaviour
{

    // Start is called before the first frame update
    public float degreesPerSecond = 105.0f;
    public float amplitude = 0.2f;
    public float frequency = 0.3f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.TryGetComponent<CrossCollectionManager>(out CrossCollectionManager Player);
            Player.CrossCount++;
            Destroy(this.gameObject);
        }
    }



}
