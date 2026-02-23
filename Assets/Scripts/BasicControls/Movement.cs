using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    protected Rigidbody2D thisObject;

    [SerializeField]
    protected StatsController stats;
    
    [SerializeField]
    private float slowDownTime = 0.1f;
    private float slowDownTimer;
    [SerializeField]
    private float speedUpTime = 0.5f;
    private float speedUpTimer;
    private float accelerationCoeff = 0.001f;

    private bool running;

    private void Update()
    {
        SlowDown();
        SpeedUp();
    }

    public void Move(Vector2 direction)
    {
        if (direction.x == 0) return;
        if (GlobalFuncs.AroundZero(thisObject.linearVelocity.x))
        {
            speedUpTimer = speedUpTime;
        }
        float walkSpeed = stats.Speed(running) * accelerationCoeff;
        thisObject.linearVelocity = new Vector2(walkSpeed * direction.x, thisObject.linearVelocity.y);
        slowDownTimer = slowDownTime;
    }
    
    private void SpeedUp()
    {
        if (speedUpTimer > 0)
        {
            speedUpTimer -= Time.deltaTime;
            accelerationCoeff = 1.0f - speedUpTimer/speedUpTime;
            if(speedUpTimer <= 0)
            {
                accelerationCoeff = 1.0f;
            }
        }
    }

    private void SlowDown()
    {
        if (slowDownTimer > 0)
        {
            slowDownTimer -= Time.deltaTime;
            if(slowDownTimer <= 0)
            {
                thisObject.linearVelocity *= Vector2.up;
                accelerationCoeff = 0.1f;
            }
        }
    }
}