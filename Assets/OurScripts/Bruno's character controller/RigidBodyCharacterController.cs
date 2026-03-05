using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider playerCollider;

    [Header("Speed")]
    //decelerating using drag

    [SerializeField] protected float deceleration;
    [SerializeField] protected float decelerationStrengh;
    [SerializeField] private float dragTime = 1f;

    [SerializeField] private float acceleration;
    [SerializeField] private float currentMaxSpeed;
    [SerializeField] public float defaultMaxSpeed;
    [SerializeField] private float boostedMaxSpeed;

     private float currentSpeed;


    [Header("Inputs")]
    float horizontalInput;
    float verticalInput;

    [Header("Camera")]
    [SerializeField] private Transform camera;
    Vector3 MoveDirection;

    [Header("Grounded")]
    [SerializeField] private LayerMask ground;
    [SerializeField] bool grounded;

    [Header("Sword")]
    [SerializeField] private SwordRecentring swordScript;


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMaxSpeed = defaultMaxSpeed;
        rb = GetComponent<Rigidbody>();
        playerCollider = rb.GetComponent<CapsuleCollider>();    
        rb.freezeRotation = true;
        swordScript = GetComponentInChildren<SwordRecentring>();
    }

    private void getInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    

    // Update is called once per frame
    void Update()
    {
        
        getCameraDireciton();
        getInput();
        isGroundedCheck(grounded, 1f);
        stopGravity(grounded);
        /*
        MultipleTapInput(KeyCode.D, 1f, 2);
        MultipleTapInput(KeyCode.A, 1f, 2);

        if(Input.GetKeyDown(KeyCode.R))
        {
            dodging = true; 
        }
        */
    }

    private void FixedUpdate()
    {
        movePlayer();


    }

    void getCameraDireciton()
    {
        Vector3 camFoward = transform.forward;
        Vector3 camRight = camera.right;

        camFoward.y = 0;
        camRight.y = 0;

        Vector3 fowardRelative = verticalInput * camFoward;
        Vector3 rightRelative = horizontalInput * camRight;

        MoveDirection = fowardRelative + rightRelative;
        MoveDirection.Normalize();
    }

    private void isGroundedCheck(bool isGrounded, float rayCastDistance)
    {
        if (Physics.Raycast(transform.position, Vector3.down, rayCastDistance, ground))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void applyGravity()
    {

    }


    private void stopGravity(bool isGrounded)
    {
        if (grounded)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }

    }




    /// <summary>
    /// notes for later
    /// 1- decelearation should change the rigidbodies velocity and not the current speed
    /// 2- Watch the video again :https://www.youtube.com/watch?v=qdskE8PJy6Q 3 minute mark and undestand the math
    /// 
    /// </summary>
    private void movePlayer()
    {
        //getting these guys for clamping later
        Vector3 velocity = rb.linearVelocity;
        Vector3 horziontalVelocity = new Vector3(velocity.x, velocity.y, velocity.y);

        //checking if theres any input from the player
        if(MoveDirection.magnitude > 0.01f)
        {
            //set the drag to 0 so the player can walk fine
            rb.linearDamping = 0;

            //target velocity, I want them to reach their top speed
            Vector3 targetVelocity = MoveDirection * currentMaxSpeed;

            // the needed speed change to reach the desired speed in a frame
            Vector3 neededAceleration = ((targetVelocity - rb.linearVelocity) / Time.fixedDeltaTime );

            //clamp it so that the required speed is not too high
            neededAceleration = Vector3.ClampMagnitude(neededAceleration, acceleration);


            rb.AddForce(Vector3.Scale(neededAceleration * rb.mass, new Vector3(1,1,1)));

        }
        else
        {
            currentSpeed -=deceleration* Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0);

            float newDrag = Mathf.Lerp(decelerationStrengh, 0, dragTime * Time.deltaTime);

            rb.linearDamping = newDrag;
            
        }
    }
}
