using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    public GameObject lightsFolder;
    private List<GameObject> lightToOff;
    //public List<GameObject> lightsChildren;
    public int lightCount;
    private GameObject lightToOn;

    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {

            //lightsChildren.Add(lightsFolder.transform.GetChild(i).gameObject);

            if (lightsFolder.transform.GetChild(i).gameObject.activeSelf)
            {
                lightToOff.Add(lightsFolder.transform.GetChild(i).gameObject);
            }
            else
            {
                Debug.Log("No Object Active");
            }
        }

        lightToOn = lightsFolder.transform.GetChild(lightCount).gameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightToOff[0].gameObject.SetActive(false);
            lightToOn.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
