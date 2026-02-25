using UnityEngine;

public class Jumping1 : MonoBehaviour
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
    private bool printed;

    private void Awake()
    {
        land.OnLand += Land;
    }

    private void FixedUpdate()
    {
        JumpTimer();
    }

    private void JumpTimer()
    {
        if (jumpTimer > 0)
        {
            printed = false;
            jumpTimer--;
        }
        else if (body.linearVelocityY < 0 && !printed)
        {
            WorldManager.Instance.SetHeight(1, transform.position.y);
            //Debug.Log("1. Base+Ticks: "+transform.position.y);
            printed = true;
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