using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    public GameObject lightsFolder;
    public List<GameObject> lightToOff;
    //public List<GameObject> lightsChildren;
    public int lightCount;
    public GameObject lightToOn;
    //public GameObject triggerFolder;
    //public List<GameObject> triggers;

    private bool isEnough = false;

    private void Start()
    {

        lightToOn = lightsFolder.transform.GetChild(lightCount).gameObject;
        Debug.Log(lightToOn);

        //for (int i = 0; i < triggerFolder.transform.childCount; i++)
        //{
        //    LightSwitcher script = triggerFolder.transform.GetComponent<LightSwitcher>();

        //    script.lightCount = i + 1;

        //    //triggers.Add(triggerFolder.transform.GetChild(i).gameObject);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetLightToOff();
            lightToOn.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void GetLightToOff()
    {
        for (int i = 0; i < lightsFolder.transform.childCount; i++)
        {
            GameObject light = lightsFolder.transform.GetChild(i).gameObject;

            if (light.activeSelf && !isEnough)
            {
                lightToOff.Add(light);
                isEnough = true;
            }
            else
            {
                Debug.Log("No Object Active");
            }

        }
        lightToOff[0].gameObject.SetActive(false);
        lightToOff.RemoveAt(0);
    } 
}
