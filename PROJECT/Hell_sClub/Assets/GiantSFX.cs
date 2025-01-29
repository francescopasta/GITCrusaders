using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSFX : MonoBehaviour
{
    public List<AudioSource> grunts;
    private float timeBetweenGrunts;
    public float minTime;
    public float maxTime;
    private int randomGrunt;
    private bool canGrunt = true;
    private void Update()
    {
        if (canGrunt) 
        {
            StartCoroutine(Grunt());
        }
    }
    public IEnumerator Grunt() 
    {
        canGrunt = false;
        timeBetweenGrunts = Random.Range(minTime, maxTime);
        randomGrunt = Random.Range(0, grunts.Count - 1);
        grunts[randomGrunt].Play();
        yield return new WaitForSeconds(timeBetweenGrunts);
        canGrunt = true;
    }
}
