using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraScript : MonoBehaviour
{
    public GameObject cameraToDisable;
    public GameObject cameraToEnable;

    private void Start()
    {
        cameraToDisable.SetActive(true);

        cameraToEnable.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnAnimationEnd()
    {
        cameraToDisable.SetActive(false);

        cameraToEnable.SetActive(true);
    }
}
