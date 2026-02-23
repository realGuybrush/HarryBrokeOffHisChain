using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField]
    private AnimatorController animator;

    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private LandTrigger land;
    
    [SerializeField]
    private float jumpSpeed = 4;

    [SerializeField]
    private float jumpTicks = 3;

    private float jumpTimer;

    private void Awake()
    {
        land.OnLand += Land;
    }

    private void Update()
    {
        JumpTimer();
    }

    private void JumpTimer()
    {
        if (jumpTimer > 0)
        {
            jumpTimer--;
        }
    }

    private void OnDestroy()
    {
        land.OnLand -= Land;
    }

    public void StartJumping()
    {
        if (!land.IsAirborne)
        {
            jumpTimer = jumpTicks;
            if (animator == null) return;
            animator.SetBoolTemporarily("Jump", true);
        }
    }
    
    public void JumpIfPossible()
    {
        if (jumpTimer <= 0) return;
        body.linearVelocityY = jumpSpeed;
        if (animator == null) return;
        animator.SetBool("Airborne", true);
    }



    public void EndJumping()
    {
        jumpTimer = 0;
    }

    private void Land()
    {
        EndJumping();
        if (animator == null) return;
        animator.SetBool("Airborne", false);
    }

    public bool IsJumping => land.IsAirborne;
}