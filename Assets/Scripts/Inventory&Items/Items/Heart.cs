using UnityEngine;

public class Heart : BasicItem
{

    [SerializeField]
    private int value = 1;
    
    
    protected override void GetPickedUp(PlayerControls player)
    {
        if (player != null)
        {
            if(player.Heal(value))
                Destroy(gameObject);
        }
    }
}