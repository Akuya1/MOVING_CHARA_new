using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement : MonoBehaviour
{

    CharacterController controller;
    Animator anim;

    public float speed = 8;
    float gravity = -9.81f;
    Vector3 playerVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        controller.Move(move.normalized * speed * Time.deltaTime);

        if(!controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        if(!controller.isGrounded)
        {
            playerVelocity.y += gravity;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        //Rotation with Raycast
    }
}
