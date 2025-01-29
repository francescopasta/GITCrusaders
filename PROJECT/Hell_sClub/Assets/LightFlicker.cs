using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightObject;
    public float first;
    public float second;
    public float e_first;
    public float e_second;
    private float Timer;
    private float timerMoment;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(first, second);
        timerMoment = Random.Range(e_first, e_second);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerMoment > 0)
        {
            timerMoment -= Time.deltaTime;
        }

        if (timerMoment <= 0)
        {
            FlickerEffect();
            timerMoment = Random.Range(e_first, e_second);
        }
    }

    private void FlickerEffect()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0)
        {
            lightObject.enabled = !lightObject.enabled;
            Timer = Random.Range(first, second);
        }
    }
}
