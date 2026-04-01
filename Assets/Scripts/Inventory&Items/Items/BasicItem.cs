using System;
using UnityEngine;

[Serializable]
public class BasicItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerControls>();
        GetPickedUp(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }

    protected virtual void GetPickedUp(PlayerControls player)
    {
    }
}
