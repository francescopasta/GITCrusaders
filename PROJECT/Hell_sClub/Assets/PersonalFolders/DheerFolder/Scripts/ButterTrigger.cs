using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterTrigger : MonoBehaviour
{
    public float JumpDebuff;
    public float OGJump;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<PlayerScript>(out PlayerScript Player);
        if (Player != null)
        {
            Player.OiledUp = true;
            OGJump = Player.JumpPower;
            Player.JumpPower = JumpDebuff;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent<PlayerScript>(out PlayerScript Player);
        if (Player != null)
        {
            Player.OiledUp = false;
            Player.JumpPower = OGJump;
        }
    }
}
