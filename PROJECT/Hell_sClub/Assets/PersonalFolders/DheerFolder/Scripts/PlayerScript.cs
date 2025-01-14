using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Values")]

    public float HorizontalInput;
    public float VerticalInput;

    public Rigidbody PlayerRigibody;

    public float WalkSpeed;
    public float SprintSpeed;
    public float MoveMultiplier;
    public Vector3 VelocityTracker;

    public float JumpHeight;
    public float JumpPower;

    public float PlayerHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        VelocityTracker = PlayerRigibody.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        if(HorizontalInput !=0 ||  VerticalInput !=0)
        { 

            PlayerRigibody.velocity = new Vector3(HorizontalInput, 0f, VerticalInput) * WalkSpeed * Time.deltaTime * MoveMultiplier; 
        
        }
    }

}
