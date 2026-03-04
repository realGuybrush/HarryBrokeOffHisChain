using UnityEngine;

public class LeftRightWalkerControls : BasicControls
{
    [SerializeField]
    private float distance = 3f;
    
    private Vector3 startPosition;

    private Vector3 direction = Vector3.left;
    private bool goingLeft = true;

    protected override void Awaking()
    {
        startPosition = transform.position;
    }

    protected override void Updating()
    {
        movement.Move(direction);
        if (transform.position.x - startPosition.x > distance && !goingLeft ||
            transform.position.x - startPosition.x < -distance && goingLeft)
        {
            direction *= -1;
            goingLeft = !goingLeft;
        }
    }
}