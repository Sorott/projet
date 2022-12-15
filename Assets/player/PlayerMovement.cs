using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    private float speed = 12f;
    public float walkSpeed;
    public float sprintSpeed;
    public float gravity = -10f;

    [Header("Keybinds")]
    private KeyCode forward = KeyCode.Z;
    public KeyCode sprintKey = KeyCode.LeftShift;

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
        air
    }

    public void StateHandler()
    {
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

    // Update is called once per frame
    void Update()
    {
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
