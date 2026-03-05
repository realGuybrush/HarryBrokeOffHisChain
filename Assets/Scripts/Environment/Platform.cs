using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform point1, point2;

    [SerializeField]
    private Vector3 direction = Vector3.left;

    [SerializeField]
    private float minStep = 0.01f;
    
    private bool goingLeft = true;

    private void FixedUpdate()
    {
        if (transform.position.x > point1.position.x && transform.position.x > point2.position.x && !goingLeft ||
            transform.position.x < point1.position.x && transform.position.x < point2.position.x && goingLeft)
        {
            direction *= -1;
            goingLeft = !goingLeft;
        }
        transform.position += direction * minStep;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BasicControls>() != null)
            other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BasicControls>() != null)
            other.transform.SetParent(null);
    }
}