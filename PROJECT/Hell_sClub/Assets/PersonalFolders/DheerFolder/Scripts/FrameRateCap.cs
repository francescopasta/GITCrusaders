using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateCap : MonoBehaviour
{
    [SerializeField] private int FrameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
    #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FrameRate;
    #endif

    }

}
