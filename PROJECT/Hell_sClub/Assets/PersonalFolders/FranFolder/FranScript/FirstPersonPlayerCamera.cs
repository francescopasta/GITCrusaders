using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerCamera : MonoBehaviour
{
    public float shakeDuration = 0.5f;  // How long the camera should shake
    public float shakeMagnitude = 0.2f; // Magnitude of the shake
    public float dampingSpeed = 1.0f;   // How quickly the shake dampens

    private Vector3 initialPosition;
    private float currentShakeDuration = 0f;

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            currentShakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
}

