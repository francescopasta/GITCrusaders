using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossItem : MonoBehaviour
{
    public enum CrossNum
    {
        Down,
        Left,
        Right
 }

    public CrossNum Type;
    public Animator UICrossAnimator;
    // Start is called before the first frame update
    public float degreesPerSecond = 105.0f;
    public float amplitude = 0.2f;
    public float frequency = 0.3f;
    public ParticleSystem ParticleBurst;
    public GameObject ObjectToHide;
    public bool turnAround;
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
        if (turnAround) 
        {
            transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        }

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
        if (ParticleBurst.gameObject.activeSelf == true)
        {
            if (ParticleBurst.isStopped)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Type == CrossNum.Down)
            {
                UICrossAnimator.SetBool("Down", true);
            }
            else if (Type == CrossNum.Left) 
            {
                UICrossAnimator.SetBool("Left", true);
            }
            else if (Type == CrossNum.Right)
            {
                UICrossAnimator.SetBool("Right", true);
            }
            other.TryGetComponent<CrossCollectionManager>(out CrossCollectionManager Player);
            Player.CrossCount++;
            ObjectToHide.SetActive(false);
            ParticleBurst.gameObject.SetActive(true);
            SphereCollider Collider = GetComponent<SphereCollider>();
            Collider.enabled = false;
        }
    }



}
