using UnityEngine;

public class Coin : BasicItem
{
    [SerializeField]
    private int value = 1;
    protected override void GetPickedUp(PlayerControls player)
    {
        if (player != null)
        {
            player.PickUpCoin(value);
            Destroy(gameObject);
        }
    }
}