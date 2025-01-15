using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Values")]

    private float HorizontalInput;
    private float VerticalInput;
    [Space(10)]
    public Rigidbody PlayerRigibody;
    [Space(10)]
    private float Speed;
    public float WalkSpeed=15f;
    public float SprintSpeed=20f;
    public float MoveMultiplier=10f;
    public float RotateSpeed=15f;
    [Space(10)]
    public Vector3 VelocityTracker;
    [Space(5)]
    [Header("Jumping Values")]
    [Space(10)]
    public bool Grounded = false;
    public float JumpPower=5f;
    public float BufferCheckDistance = 0.1f;
    public float GroundDrag;
    public float AirDrag;
    [Space(10)]
    public float Gravity = 9.8f;
    

    private float GroundCheckDistance;
    
    [Space(10)]
    public float PlayerHealth = 100f;

    [Header("Camera and other References")]
    public Camera MainCam;

    // Start is called before the first frame update
    void Awake()
    {
        Speed = WalkSpeed;
        PlayerRigibody = GetComponent<Rigidbody>();
        VelocityTracker = PlayerRigibody.velocity;
        MainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + BufferCheckDistance;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;

        }
        else
        {
            Speed = WalkSpeed; 
        }
        if (Input.GetKeyDown(KeyCode.Space)&&Grounded)
        {
            Jump();
        }
        RaycastHit PlayerHit;
        if(Physics.Raycast(transform.position, -transform.up, out PlayerHit, GroundCheckDistance))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        if (Grounded)
        {
            PlayerRigibody.drag = GroundDrag;

        }
        else
        {
            PlayerRigibody.drag = AirDrag;
        }
    }
    private void FixedUpdate()
    {
        MovementandRotation();
        GravityAdd();

    }
    public void MovementandRotation()
    {
        Vector3 Right = Vector3.Cross(Vector3.up, MainCam.transform.forward);
        Vector3 Forward = Vector3.Cross(Right, Vector3.up);

        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        Vector3 MovementInput = Vector3.zero;

        Vector3 RightVector = Right * (HorizontalInput * Speed * Time.deltaTime * MoveMultiplier);
        Vector3 ForwardVector = Forward * (VerticalInput * Speed * Time.deltaTime * MoveMultiplier);
        

        MovementInput += ForwardVector + RightVector ;
        
        PlayerRigibody.AddForce( MovementInput , ForceMode.VelocityChange);
        
        if(MovementInput != Vector3.zero)
        {
            Quaternion Rotation = Quaternion.LookRotation(MovementInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotateSpeed);
        }
        
    }

    public void AdjustSpeed(float multiplier)
    {
        Speed = Speed * multiplier;
    }

    public void ResetSpeed()
    {
        Speed = WalkSpeed;
    }

    public void SpeedControl()
    {
        //Lets see this in a minute
    }

    public void Jump()
    {
        PlayerRigibody.AddForce(new Vector3(0f,JumpPower,0f), ForceMode.VelocityChange);
    }

    public float CheckNearestGround() 
    {
        RaycastHit hit;
        Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z);

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit))
        {
            // The ray hit something, and the position of the hit is stored in hit.point
            Vector3 groundPosition = hit.point;
            Debug.Log("Ground position: " + groundPosition);
            return groundPosition.y;
        }
        else
        {
            return 0f;
        }
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ground"))
    //    {
    //        Grounded = true;
    //    }
    //}
    //public void OnTriggerExit(Collider other)
    //{
    //    Grounded = false;
    //}


}
