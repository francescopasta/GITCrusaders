using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public List<GameObject> textObjects;
    int index = 0;
    void Start()
    {
        foreach (Transform item in transform)
        {
            textObjects.Add(item.gameObject);
        }
        textObjects[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && index < textObjects.Count - 1)
        {
            index++;
            if (index - 1 >= 0)
            {
                textObjects[index - 1].SetActive(false);
            }
            textObjects[index].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && index + 1 >= textObjects.Count -1)
        {
            textObjects[index].SetActive(false);
        }
        
    }
}
