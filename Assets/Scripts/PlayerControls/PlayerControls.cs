using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : BasicControls
{
    [SerializeField]
    private PlayerInput playerInputActions;

    [SerializeField]
    private UICounter coinCounter;

    [SerializeField]
    private HealthUI healthUI;

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
        jump?.Disable();
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

    public void PickUpCoin(int amount)
    {
        coinCounter?.AddCountable(amount);
    }

    public bool Heal(int amount)
    {
        if (health.Heal(amount))
        {
            healthUI.Heal(amount);
            return true;
        }
        return false;
    }

    protected override void ReceiveDamage(Vector3 direction, int amount)
    {
        base.ReceiveDamage(direction, amount);
        healthUI.GetDamaged(amount);
    }
}
