using System.Collections;
using UnityEngine;

public class Jumping : MonoBehaviour
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
    private float jumpTime =  0.2f;

    private int unendedJumpCoroutines;
    private int endedJumpCoroutines;

    private float defaultGravityScale;

    private void Awake()
    {
        head.OnLand += EndJumping;
        land.OnLand += Land;
        defaultGravityScale = body.gravityScale;
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
            StartCoroutine("WaitToMaximizeJump");
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

    private IEnumerator WaitToMaximizeJump()
    {
        unendedJumpCoroutines++;
        yield return new WaitForSeconds(jumpTime);
        endedJumpCoroutines++;
        if (endedJumpCoroutines == unendedJumpCoroutines)
        {
            unendedJumpCoroutines = 0;
            endedJumpCoroutines = 0;
            EndJumping();
        }
    }

    public bool IsJumping => land.IsAirborne;
}