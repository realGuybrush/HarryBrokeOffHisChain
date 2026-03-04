using UnityEngine;

public class MobBasicControls : BasicControls
{
    protected void Follow(Vector3 followPoint)
    {
        Vector3 direction = GlobalFuncs.TurnIntoDirectionVector(followPoint - transform.position);
        HandleMoveCommand(direction);
    }
}
