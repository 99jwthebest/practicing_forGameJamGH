using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed;

    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] Animator playerAnimator;

    [SerializeField] bool facingRight;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        facingRight = true;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("speed", Mathf.Abs(move));

        playerRigidBody.velocity = new Vector3(move * runSpeed, playerRigidBody.velocity.y, 0);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}
