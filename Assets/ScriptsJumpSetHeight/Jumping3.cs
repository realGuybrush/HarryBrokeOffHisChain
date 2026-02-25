using System;
using System.Collections;
using UnityEngine;

public class Jumping3 : MonoBehaviour
{
    [SerializeField]
    private AnimatorController animator;

    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private LandTrigger head, land;
    
    [SerializeField]
    private float jumpSpeed = 5f;

    [SerializeField]
    private float jumpHeight =  2f;

    private float jumpStartY, jumpEndY;

    private float defaultGravityScale;
    private bool printed; 

    private void Awake()
    {
        head.OnLand += EndJumping;
        land.OnLand += Land;
        defaultGravityScale = body.gravityScale;
    }

    private void FixedUpdate()
    {
        if (land.IsAirborne)
            if(transform.position.y >= jumpEndY)
                EndJumping();
    }

    private void OnDestroy()
    {
        head.OnLand -= EndJumping;
        land.OnLand -= Land;
    }

    public void StartJumping()
    {
        if (!land.IsAirborne)
        {
            printed = false;
            jumpStartY = transform.position.y;
            jumpEndY = jumpStartY + jumpHeight;
            body.linearVelocityY = jumpSpeed;
            body.gravityScale = 0f;
            InitJumpAnimations();
        }
    }

    private void InitJumpAnimations()
    {
        if (animator == null) return;
        animator.SetBoolTemporarily("Jump", true);
        animator.SetBool("Airborne", true);
    }

    public void EndJumping()
    {
        body.gravityScale = defaultGravityScale;
        if (!printed && body.linearVelocityY < 0)
        {
            WorldManager.Instance.SetHeight(3, transform.position.y);
            //Debug.Log("3. MaxHeight: "+ transform.position.y);
            printed = true;
        }
    }

    private void Land()
    {
        EndJumping();
        InitLandAnimation();
    }

    private void InitLandAnimation()
    {
        if (animator == null) return;
        animator.SetBool("Airborne", false);
    }

    public bool IsJumping => land.IsAirborne;
}