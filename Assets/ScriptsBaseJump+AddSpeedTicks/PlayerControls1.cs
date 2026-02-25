using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls1 : BasicMovement1
{
    [SerializeField]
    private PlayerInput playerInputActions;

    private InputAction move, jump, normalAttack;

    protected override void Updating()
    {
        base.Updating();
        PlayerCheckMove();
        PlayerCheckJump();
    }

    private void OnEnable()
    {
        SetInputActions();
        EnableInputActions();
        SetEvents();
    }

    private void OnDisable()
    {
        RemoveEvents();
        DisableInputActions();
    }

    private void SetInputActions()
    {
        move = playerInputActions.actions.FindAction("Move");
        jump = playerInputActions.actions.FindAction("Jump");
        normalAttack = playerInputActions.actions.FindAction("Attack");
    }

    private void EnableInputActions()
    {
        move?.Enable();
        jump?.Enable();
        normalAttack?.Enable();
    }

    private void SetEvents()
    {
        normalAttack.started += StartNormalAttack;
        normalAttack.canceled += EndNormalAttack;
        jump.canceled += HandleJumpEndCommand;
    }

    private void RemoveEvents()
    {
        normalAttack.started -= StartNormalAttack;
        normalAttack.canceled -= EndNormalAttack;
        jump.canceled -= HandleJumpEndCommand;
    }

    private void DisableInputActions()
    {
        move?.Disable();
        normalAttack?.Disable();
    }

    private void PlayerCheckMove()
    {
        HandleMoveCommand(move.ReadValue<Vector2>());
    }

    private void PlayerCheckJump()
    {
        if (jump.IsPressed())
        {
            HandleJumpStartCommand();
            HandleJumpCommand();
        }
    }
    
    private void StartNormalAttack(InputAction.CallbackContext context)
    {
        if (jumping != null && jumping.IsJumping) return;
        Attack(true);
    }
    
    private void EndNormalAttack(InputAction.CallbackContext context)
    {
        Attack(false);
    }
}
