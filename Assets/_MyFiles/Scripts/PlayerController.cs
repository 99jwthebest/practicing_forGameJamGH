using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float defaultSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float fullAppraisalSpeed;
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
    [SerializeField] Vector3 moveDir;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;

    bool firstGrounded = true;
    //int recoilAnimation;




    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        facingRight = true;
        tR.emitting = false;
        defaultSpeed = runSpeed;

        //recoilAnimation = Animator.StringToHash("PistolShootRecoil");

    }


    public bool GetGroundedRealTime()
    {
        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        return groundCollisions.Length > 0;
    }

    void Update()
    {

        if (CountupTimer.instance.gameEnd)
        {
            playerAnimator.enabled = false;
            return;
        }

        //if (isDashing)
        //    return;
        //animator.CrossFade(recoilAnimation, animationPlayTransition);

        //MoveCharacterMovingPlatforms();
        firstGrounded = true;
        playerAnimator.SetBool("firstGrounded", firstGrounded);

        DoubleJump();
        Jump();

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0)
            isGrounded = true;
        else
            isGrounded = false;

        playerAnimator.SetBool("isGrounded", isGrounded);

        move = Input.GetAxis("Horizontal");
        moveDir = new Vector3(move, 0, 0);
        playerAnimator.SetFloat("speed", Mathf.Abs(move));

        float sneaking = Input.GetAxisRaw("Fire3");
        playerAnimator.SetFloat("sneaking", sneaking);

        float verticalSpeed = playerRigidBody.velocity.magnitude;
        playerAnimator.SetFloat("verticalSpeed", verticalSpeed);

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

    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            firstGrounded = false;
            playerAnimator.SetBool("firstGrounded", firstGrounded);
            playerRigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            jumpCount = 1;
        }
    }

    private void DoubleJump()
    {
        
        if (!isGrounded && Input.GetKeyDown(KeyCode.Space) && jumpCount >= 1)
        {
            Debug.Log("Only in here when in air!");
            playerRigidBody.Sleep();
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

    public void MoveCharacterOnMovingPlatforms()
    {
        playerRigidBody.isKinematic = true;
        //onMovingPlatform = true;
    }

    public void MoveCharacterMovingPlatforms()
    {
        if(playerRigidBody.isKinematic)
        {
            Debug.Log("on the moving Platss!!!");
            transform.localPosition += moveDir.normalized * 3 * Time.deltaTime;

        }

    }

    public void MoveCharacterOffMovingPlatforms() 
    {
        playerRigidBody.isKinematic = false;
        //onMovingPlatform = true;
    }

    public void MakePlayerFasterSpeedAppraisalMeter()
    {
        runSpeed = fullAppraisalSpeed;
    }

    public void MakePlayerNormalSpeedAppraisalMeter()
    {
        runSpeed = defaultSpeed;
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
