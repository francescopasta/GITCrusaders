using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class MuffledEffect : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioMixerGroup musicMixer;
    public float transitionTime;
    public float targetCutoff;
    public float normalCutoff;
    public float muffledCutoff;
    private AudioLowPassFilter lowPassFilter;
    private void Start()
    {
        // Get or add the AudioLowPassFilter component from the AudioSource
        lowPassFilter = musicSource.GetComponent<AudioLowPassFilter>();
        if (lowPassFilter == null)
        {
            lowPassFilter = musicSource.gameObject.AddComponent<AudioLowPassFilter>();
        }

        lowPassFilter.cutoffFrequency = normalCutoff;
    }
    private void OnTriggerEnter(Collider other)
    {
       StartCoroutine(ChangeMusic(targetCutoff));
    }
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(ChangeMusic(normalCutoff));
    }
    public IEnumerator ChangeMusic(float target) 
    {
        float currentCutoff = lowPassFilter.cutoffFrequency;
        float elapsedTime = 0;

        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            lowPassFilter.cutoffFrequency = Mathf.Lerp(currentCutoff, target, elapsedTime / transitionTime);
            yield return null;
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MuffledEffect : MonoBehaviour
//{
//    public List<AudioLowPassFilter> lowPassFilter;
//    //public List<Camera> cameras; 
//    public float normalCutoff = 22000f;  // Normal hearing range (no muffling)
//    public float muffledCutoff = 800f;   // Muffled sound effect
//    public float transitionSpeed = 2f;   // How fast the filter adjusts

//    private float targetCutoff;

//    void Start()
//    {

//        //foreach (Camera camera in cameras)
//        //{
//        //    lowPassFilter.Add(camera.GetComponent<AudioLowPassFilter>());
//        //}

//        targetCutoff = normalCutoff;
//    }

//    void Update()
//    {
//        // Smoothly transition between normal and muffled sounds
//        foreach (AudioLowPassFilter filter in lowPassFilter)
//        {
//            filter.cutoffFrequency = Mathf.Lerp(filter.cutoffFrequency, targetCutoff, Time.deltaTime * transitionSpeed);
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//            targetCutoff = muffledCutoff;
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            targetCutoff = normalCutoff;
//        }
//    }
//}
