using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCollectionManager : MonoBehaviour
{
    public PlayerScript Player;
    public Animator UIAnimator;
    public int CrossCount = 0;
    public int MaxCount = 3;
    public bool All3 = false;
    public GameObject finalCross;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerScript>();
        CrossCount = 0;        

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossCount >= MaxCount && !All3)
        {
            CrossCount = 3;
            Debug.Log("All Gotten :0");
            All3 = true;
            finalCross.SetActive(true);
        }
        //UIAnimator.SetFloat("Cross", CrossCount);
    }
}
