using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController controller;
    private float speed = 0f;
    public float walkSpeed;
    public float sprintSpeed;
    public float gravity = -10f;

    [Header("Crounch")]
    public float crounchspeed;
    public float crounchYScale;
    private float startYScale;

    [Header("Keybinds")]
    private KeyCode forward = KeyCode.W;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crounchKey = KeyCode.LeftControl;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        crounching,
        air
    }

    private void MyInput()
    {
        if (Input.GetKeyDown(crounchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crounchYScale, transform.localScale.z);
        }

        if (Input.GetKeyUp(crounchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
    public void StateHandler()
    {
        if (Input.GetKey(crounchKey))   
        {
            state = MovementState.crounching;
            speed = crounchspeed;
        }

        if (isGrounded && Input.GetKey(sprintKey) && Input.GetKey(forward))
        {
            state = MovementState.sprinting;
            speed = sprintSpeed;
        }
        else if (isGrounded)
        {
            state = MovementState.walking;
            speed = walkSpeed;
        }
        else
        {
            state = MovementState.air;
        }
    }

    private void Start()
    {
        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        StateHandler();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
