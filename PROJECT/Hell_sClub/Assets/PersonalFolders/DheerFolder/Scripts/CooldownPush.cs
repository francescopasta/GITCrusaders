using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CooldownPush : MonoBehaviour
{
    public Image CooldownFill;
    public float CooldownTime;
    public float NextTime;
    // Start is called before the first frame update
    public bool IsCoolingDown => Time.time < NextTime;
    public void Awake()
    {
        StartCooldown();
    }
    public void StartCooldown() 
    {
        NextTime = Time.time + CooldownTime; 

        
    }
    void FixedUpdate()
    {
        CooldownFill.fillAmount = (CooldownTime - (NextTime - Time.time)) / CooldownTime;
    }
}
