using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        //Get Direction to Move
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");


        //Set Movement
        controller.Move(direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", controller.velocity.magnitude);
        //Set Rotation
        if(controller.velocity.magnitude > 0) transform.forward = controller.velocity;

        //Jump
        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += jumpForce;
        }

        velocity += Physics.gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
