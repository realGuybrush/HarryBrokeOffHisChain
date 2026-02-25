using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class BasicMovement3 : MonoBehaviour
{
    [SerializeField]
    protected AnimatorController animator;

    [SerializeField]
    protected Transform visualPart;
    
    [SerializeField]
    private Health health;

    [SerializeField]
    protected Movement movement;

    [SerializeField]
    protected Jumping3 jumping;

    [SerializeField]
    private Weapon weapon;
    
    private bool attacking;

    private Vector3 flipAngle = new Vector3(0f, 180f, 0f);
    
    private void Awake()
    {
        Awaking();
    }

    private void Update()
    {
        Updating();
    }

    protected virtual void Awaking()
    {
        
    }

    protected virtual void Updating()
    {
    }

    ///////MOVE///////
    public void HandleMoveCommand(Vector2 direction)
    {
        SetMovingAnimation(direction);
        if (!attacking)
            movement.Move(direction);
    }

    private void SetMovingAnimation(Vector2 direction)
    {
        if (animator == null) return;
        if (direction.x < 0 && GlobalFuncs.AroundZero(visualPart.eulerAngles.y))
            visualPart.Rotate(-flipAngle);
        if (direction.x > 0 && (visualPart.eulerAngles.y > 179f && visualPart.eulerAngles.y < 181f))
            visualPart.Rotate(flipAngle);
        animator.SetBool("Move", direction.x != 0);
    }
    public void HandleJumpStartCommand()
    {
        jumping.StartJumping();
    }
    
    public void HandleJumpEndCommand()
    {
        jumping.EndJumping();
    }
    
    public void HandleJumpEndCommand(InputAction.CallbackContext context)
    {
        jumping.EndJumping();
    }

    ///////ACTIONS AND ATTACKS///////

    protected void Attack(bool attack)
    {
        if (weapon == null)
        {
            //Debug.Log("GameObject with damaging collider (representation of fist, weapon, etc.) is missing.");
            return;
        }
        attacking = attack;
        if(animator != null)
            animator.SetBool("Attack", attacking);
    }

    ///////HEALTH///////

    public bool IsAlive => health.HP > 0;

    ///////SAVE&LOAD///////
/*
    public void BasicLoadData(SaveData saveData)
    {
        transform.position = saveData.position.ToV3();
        transform.eulerAngles = saveData.rotation.ToV3();
        //thisObject.velocity = saveData.velocity.ToV3();
        health.LoadValues(saveData.damage, saveData.defense, saveData.health);
        if (transform.eulerAngles.y != 0)
        {
            //facingRight = false;
        }
    }*/
}
