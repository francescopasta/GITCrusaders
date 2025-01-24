using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static Unity.Burst.Intrinsics.X86.Avx;

public class CameraDistortEffect : MonoBehaviour
{
    public Volume Volume;
    public LensDistortion LensDistort;
    
    [Range(0.0f, 1.0f)]
    public float DistortX;
    [Range(0.0f, 1.0f)]
    public float DistortY;

    public float TimeMultiX;
    public float TimeMultiY;

    private void Start()
    {
        if (Volume.profile.TryGet<LensDistortion>(out LensDistortion temp))
        {
            LensDistort = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        LensDistort.xMultiplier.value = Mathf.PingPong(Time.time*TimeMultiX, DistortX);
        LensDistort .yMultiplier.value = Mathf.PingPong(Time.time*TimeMultiY, DistortY);
    }
}
