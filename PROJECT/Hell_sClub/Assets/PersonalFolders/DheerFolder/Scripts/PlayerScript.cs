using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Values")]

    private float HorizontalInput;
    private float VerticalInput;
    [Space(10)]
    public Rigidbody PlayerRigibody;
    public Vector3 MovementInput;
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
    [Header("Slope Handling")]
    public float MaxSlopeAngle;
    private RaycastHit SlopeHit;
    public float SlopeMulti;

    public float Gravity = 9.8f;
    

    private float GroundCheckDistance;
    
    [Space(10)]
    [Header("Abilites/Parameters")]
    public float PlayerHealth = 100f;
    public bool OiledUp = false;
    public bool CanPush=true;
    public float PushForce=300f;
    public float PushRadius=10f;
    public float PushUpModifier=1f;

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
        if (Input.GetKeyDown(KeyCode.E) && CanPush)
        {
            Push();
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

        MovementInput = Vector3.zero;

        Vector3 RightVector = Right * (HorizontalInput * Speed * Time.deltaTime * MoveMultiplier);
        Vector3 ForwardVector = Forward * (VerticalInput * Speed * Time.deltaTime * MoveMultiplier);
        

        MovementInput += ForwardVector + RightVector ;
        
        PlayerRigibody.AddForce( MovementInput , ForceMode.VelocityChange);
        if (OnSlope())
        {
            PlayerRigibody.AddForce(GetSlopeMoveDirection() * Speed * SlopeMulti, ForceMode.Force);
            Grounded = true;
        }

        if(MovementInput != Vector3.zero)
        {
            Quaternion Rotation = Quaternion.LookRotation(MovementInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotateSpeed);
        }
        ClampVelocity();
        if (!OiledUp)
        {
           
            GroundDrag = 8f;
        }
        else
        {
            GroundDrag = 0f;
        }
    }
    private void ClampVelocity()
    {
        Vector3 FlatVelocity = new Vector3(PlayerRigibody.velocity.x, 0, PlayerRigibody.velocity.z);

        if (FlatVelocity.magnitude > Speed)
        {
            FlatVelocity = FlatVelocity.normalized * Speed;
            PlayerRigibody.velocity = new Vector3(FlatVelocity.x, PlayerRigibody.velocity.y, FlatVelocity.z);
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

    //public void SpeedControl()
    //{
    //    Vector3 FlatVelocity = new Vector3(PlayerRigibody.velocity.x, 0f, PlayerRigibody.velocity.z);

    //    if (FlatVelocity.magnitude > Speed)
    //    {
    //        Vector3 LimitedVel = FlatVelocity.normalized * Speed;
    //        PlayerRigibody.velocity = new Vector3(LimitedVel.x, PlayerRigibody.velocity.y, LimitedVel.z);
    //    }
    //}

    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out SlopeHit, (GetComponent<CapsuleCollider>().height / 2) + 0.3f)) ;
        {
            float Angle = Vector3.Angle(Vector3.up, SlopeHit.normal);
            return Angle < MaxSlopeAngle && Angle!=0;
            
        }
        return false;
    }
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(MovementInput, SlopeHit.normal).normalized; 
    }
    public void Jump()
    {
        PlayerRigibody.AddForce(new Vector3(0f,JumpPower,0f), ForceMode.VelocityChange);
    }
    public void GravityAdd()
    {

        PlayerRigibody.AddForce(new Vector3(0.0f, Gravity * -1f, 0.0f), ForceMode.Acceleration);
        
    }

    public void Push()
    {
        Collider[] PushedObjects = Physics.OverlapSphere(transform.position, PushRadius);
        List<Collider> pushedObjectsList = new List<Collider>();
        foreach (Collider collider in PushedObjects)
        {
            pushedObjectsList.Add(collider);
        }
        foreach (Collider collider in pushedObjectsList) 
        {
            Rigidbody rigidbody;
            if (collider.attachedRigidbody != null && !collider.gameObject.CompareTag("Player"))
            {
                rigidbody = collider.GetComponent<Rigidbody>();
                rigidbody.AddExplosionForce(PushForce, rigidbody.transform.position, PushRadius,PushUpModifier , ForceMode.Force);
            }
            else
            {
                continue;
            }
        }    
       
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
    //public bool SetSlip(bool Value)
    //{
    //    OiledUp = Value;
    //}
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
