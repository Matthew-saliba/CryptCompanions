using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Animator animator;

    private bool isPlayerGrounded;
    [SerializeField] private float playerSpeed = 5.5f;
    private float gravityValue = -9.81f;
    bool isWalking;

    void Awake(){
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();

        //Ensuring the player will always have a character controller 
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }

        // Add Animator if missing
        if (animator == null)
        {
            animator = gameObject.AddComponent<Animator>();
        }
    }

    void Update()
    {
        isPlayerGrounded = controller.isGrounded;
        if (isPlayerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        isWalking = move != Vector3.zero;

        if (isWalking)
        {
            transform.forward = move;
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
        
        // Update animator parameter
        if (animator != null)
        {
            animator.SetBool("IsWalking", isWalking);
        }
    }
}