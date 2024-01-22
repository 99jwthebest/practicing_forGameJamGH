using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;

    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] Animator playerAnimator;

    [SerializeField] bool facingRight;

    // for jumping
    [SerializeField] bool isGrounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpHeight;
    [SerializeField] int jumpCount;



    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        facingRight = true;
    }

    private void FixedUpdate()
    {

        
    }

    void Update()
    {
        DoubleJump();
        Jump();

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        playerAnimator.SetBool("isGrounded", isGrounded);

        float move = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("speed", Mathf.Abs(move));

        float sneaking = Input.GetAxisRaw("Fire3");
        playerAnimator.SetFloat("sneaking", sneaking);
        
        if(sneaking > 0 && isGrounded)
            playerRigidBody.velocity = new Vector3(move * walkSpeed, playerRigidBody.velocity.y, 0);
        else
            playerRigidBody.velocity = new Vector3(move * runSpeed, playerRigidBody.velocity.y, 0);


        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    UIManager.instance.UpdateHealth();
        //}
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            playerAnimator.SetBool("isGrounded", isGrounded);
            playerRigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            jumpCount = 1;
        }
    }

    private void DoubleJump()
    {
        
        if (!isGrounded && Input.GetKeyDown(KeyCode.Space) && jumpCount >= 1)
        {
            Debug.Log("Only in here when in air!");
            playerRigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            jumpCount = 0;
        }
    }

    private void GroundSlam()
    {

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    public float GetPlayerDirection()
    {
        if (facingRight)
            return 1;
        else 
            return -1;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}
