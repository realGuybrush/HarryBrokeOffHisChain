using System;
using UnityEngine;

public class JumpStopper :MonoBehaviour
{
    [SerializeField]
    private Jumping player;

    private Vector3 YOffset;

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y);
    }

    public void SetOffset(float yOffset)
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.EndJumping();
    }
}