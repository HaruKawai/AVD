using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DControll : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    //Climb
    public float distance;
    public LayerMask whatIsLadder;
    float verticalMove = 0f;
    private Rigidbody2D rb;
    //
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    bool climb = false;
    bool isClimbing;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        //Debug.Log(crouch);
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);

    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    
    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,
Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetButtonDown("Climb"))
            {
                isClimbing = true;
            }
        }

        if (isClimbing == true)
        {
            verticalMove = Input.GetAxisRaw("Vertical");
        }
        //
        jump = false;
    }
    
}