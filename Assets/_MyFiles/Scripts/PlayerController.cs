using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float platformSpeed;
    float move;

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

    // for dashing
    [SerializeField] bool canDash = true;
    [SerializeField] bool isDashing;
    [SerializeField] float dashingPower = 24f;
    [SerializeField] float dashingTime = 0.2f;
    [SerializeField] float dashingCooldown = 1f;

    [SerializeField] TrailRenderer tR;

    [SerializeField] public bool onMovingPlatform;




    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        facingRight = true;
        tR.emitting = false;

    }

    private void FixedUpdate()
    {

        
    }

    void Update()
    {
        //if (isDashing)
        //    return;

        DoubleJump();
        Jump();

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        playerAnimator.SetBool("isGrounded", isGrounded);

        move = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("speed", Mathf.Abs(move));

        float sneaking = Input.GetAxisRaw("Fire3");
        playerAnimator.SetFloat("sneaking", sneaking);

        //if (onMovingPlatform)
        //    playerRigidBody.velocity = new Vector3(move * platformSpeed, playerRigidBody.velocity.y, 0);
        //else
            playerRigidBody.velocity = new Vector3(move * runSpeed, playerRigidBody.velocity.y, 0);


        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            StartCoroutine(Dash());

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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        playerRigidBody.useGravity = false;
        //playerRigidBody.velocity = new Vector3(move * dashingPower, 0, 0);

        tR.emitting = true;
        float dashing = 0f;
        while(dashing < 10f)
        {
            playerRigidBody.AddForce(new Vector3(move * dashingPower, 0, 0), ForceMode.Force);
            dashing++;
            yield return new WaitForSeconds(.01f);

        }
        //yield return new WaitForSeconds(dashingTime);
        tR.emitting = false;
        playerRigidBody.useGravity = true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
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

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, slashRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
