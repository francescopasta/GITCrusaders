using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightObject;
    public float minInterval = 5f; // Minimum time before flicker starts
    public float maxInterval = 8f; // Maximum time before flicker starts
    public float flickerDuration = 1f; // How long the flickering lasts
    public float flickerSpeed = 0.1f; // Speed of flickering

    private float nextFlickerTime;
    private bool isFlickering = false;

    void Start()
    {
        ScheduleNextFlicker();
    }

    void Update()
    {
        if (!isFlickering && Time.time >= nextFlickerTime)
        {
            StartCoroutine(FlickerEffect());
        }
    }

    private IEnumerator FlickerEffect()
    {
        isFlickering = true;
        float flickerEndTime = Time.time + flickerDuration;

        while (Time.time < flickerEndTime)
        {
            lightObject.enabled = !lightObject.enabled;
            yield return new WaitForSeconds(flickerSpeed);
        }

        lightObject.enabled = true; // Ensure light stays on after flicker
        isFlickering = false;
        ScheduleNextFlicker();
    }

    private void ScheduleNextFlicker()
    {
        nextFlickerTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}
