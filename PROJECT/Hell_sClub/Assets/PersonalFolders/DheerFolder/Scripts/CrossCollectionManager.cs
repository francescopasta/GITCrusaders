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
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerScript>();
        CrossCount = 0;        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
