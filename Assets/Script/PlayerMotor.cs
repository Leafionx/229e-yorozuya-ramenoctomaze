using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 playerVelocity;
    private bool IsGrounded;

    public float speed = 5f;

    public float gravity = -9.8f;

    public float jumpHeight = 3f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        var velocity = Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity);
        animator.SetFloat("Speed",velocity.magnitude);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(IsGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
