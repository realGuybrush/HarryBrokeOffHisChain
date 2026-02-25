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
    private float jumpHeight =  1.5f;

    [SerializeField]
    private JumpStopper jumpStopper;

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
            jumpStopper.SetOffset(jumpHeight);
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

    public bool IsJumping => land.IsAirborne;
}