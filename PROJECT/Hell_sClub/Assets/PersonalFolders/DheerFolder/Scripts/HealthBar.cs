using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerScript Player;
    public Image HealthFill;


    // Start is called before the first frame update
    //void Awake()
    //{
    //    Player = GetComponent<PlayerScript>();
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        HealthFill.fillAmount = (Player.PlayerHealth)/100f;
    }
}
