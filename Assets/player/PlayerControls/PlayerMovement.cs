using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Mouvement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Stamina")]
    public float stamina;
    public float maxStamina;
    public bool isRunning;

    [Header("Crounching")]
    public float crounchSpeed;
    public float crounchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode sprintKey= KeyCode.LeftShift;
    public KeyCode crounchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisGround;
    bool grounded;

    [Header("Slop Handling")]
    public float maxSlopAngle;
    private RaycastHit slopHit;

    public Transform orientation;

    public AudioSource walksound;

    float horizontalInput;
    float verticaleInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crounching,
        air
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startYScale = transform.localScale.y;

        walksound.Stop();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisGround);

        MyInput();
        SpeedControle();
        StateHandler();

        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        {
            rb.drag = 0;
        }

        if (isRunning == true)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
            }
            if (stamina <= 0)
            {
                moveSpeed = walkSpeed;
            }
        }

        else if (stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticaleInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(crounchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crounchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crounchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void StateHandler()
    {
        if (Input.GetKey(crounchKey))
        {
            state = MovementState.crounching;
            moveSpeed = crounchSpeed;

            isRunning = false;
        }

        if (Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;

            isRunning = true;
        }

        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;

            isRunning = false;
        }

        else
        {
            state = MovementState.air;

            isRunning = false;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticaleInput + orientation.right * horizontalInput;

        if (OnSlope())
        {
            rb.AddForce(GetSlopMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        rb.useGravity = !OnSlope();
    }

    private void SpeedControle()
    {
        if (OnSlope())
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }

        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopHit.normal);
            return angle < maxSlopAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopHit.normal).normalized;
    }
}
