using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Values")]

    public float HorizontalInput;
    public float VerticalInput;

    public Rigidbody PlayerRigibody;

    private float Speed;
    public float WalkSpeed=15f;
    public float SprintSpeed=20f;
    public float MoveMultiplier=10f;
    public float RotateSpeed=15f;
    public Vector3 VelocityTracker;

    public float JumpHeight=5f;
    public float JumpPower=5f;

    public float PlayerHealth=100f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Speed = WalkSpeed;
        PlayerRigibody = GetComponent<Rigidbody>();
        VelocityTracker = PlayerRigibody.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        MovementandRotation();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;

        }
        else
        {
            Speed = WalkSpeed; 
        }
    }

    public void MovementandRotation()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        Vector3 MovementInput = new Vector3(HorizontalInput, 0f, VerticalInput);
        
        PlayerRigibody.velocity = (MovementInput * Speed * Time.deltaTime * MoveMultiplier) + new Vector3(0f,PlayerRigibody.velocity.y,0f);
        if(MovementInput != Vector3.zero)
        {
            Quaternion Rotation = Quaternion.LookRotation(MovementInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotateSpeed);
        }
        //PlayerRigibody.rotation = Quaternion.Euler(0f, , 0f);
    }

}
