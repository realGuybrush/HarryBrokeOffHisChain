using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float minX, maxX;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if(player.position.x > minX && player.position.x < maxX)
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

}
