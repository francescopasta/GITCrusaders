using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffledEffect : MonoBehaviour
{
    public List<AudioLowPassFilter> lowPassFilter;
    //public List<Camera> cameras; 
    public float normalCutoff = 22000f;  // Normal hearing range (no muffling)
    public float muffledCutoff = 800f;   // Muffled sound effect
    public float transitionSpeed = 2f;   // How fast the filter adjusts

    private float targetCutoff;

    void Start()
    {

        //foreach (Camera camera in cameras)
        //{
        //    lowPassFilter.Add(camera.GetComponent<AudioLowPassFilter>());
        //}

        targetCutoff = normalCutoff;
    }

    void Update()
    {
        // Smoothly transition between normal and muffled sounds
        foreach (AudioLowPassFilter filter in lowPassFilter) 
        {
            filter.cutoffFrequency = Mathf.Lerp(filter.cutoffFrequency, targetCutoff, Time.deltaTime * transitionSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            targetCutoff = muffledCutoff; 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetCutoff = normalCutoff; 
        }
    }
}
