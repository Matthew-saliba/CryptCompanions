using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isPlayerGrounded;
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    private Animation walkingAnimation;
    private Animation idleAnimation;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        //Ensuring the player will always have a character controller 
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
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

        if (move != Vector3.zero)
        {
            transform.forward = move;


            // Apply gravity
            playerVelocity.y += gravityValue * Time.deltaTime;

            // Combine horizontal and vertical movement
            Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
            controller.Move(finalMove * Time.deltaTime);
        }
        
        Animations();
    }

    void Animations()
    {
        while (playerVelocity.x > 0 || playerVelocity.z > 0)
        {
            // Play walking animation
            if (walkingAnimation != null)
            {
                walkingAnimation.Play();
            }
        }

        while (playerVelocity.x <= 0 && playerVelocity.z <= 0)
        {
            // Play idle animation
            if (idleAnimation != null)
            {
                idleAnimation.Play();
            }
        }
    }
}