using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class BasicControls : MonoBehaviour
{
    [SerializeField]
    protected AnimatorController animator;
    
    [SerializeField]
    protected Rigidbody2D thisBody;

    [SerializeField]
    protected Transform visualPart;
    
    [SerializeField]
    private Health health;

    [SerializeField]
    protected Movement movement;

    [SerializeField]
    protected Jumping jumping;

    [SerializeField]
    private Weapon weapon;
    
    private bool attacking;

    private Vector3 flipAngle = new Vector3(0f, 180f, 0f);

    private float defaultKickForce = 10f;
    
    private void Awake()
    {
        Awaking();
    }

    private void Update()
    {
        Updating();
    }

    private void OnDestroy()
    {
        OnDestroying();
    }

    protected virtual void Awaking()
    {
        if (health != null)
        {
            health.OnDie += Die;
            health.OnDamaged += ReceiveDamage;
        }
    }

    protected virtual void Updating()
    {
    }

    protected virtual void OnDestroying()
    {
        if (health != null)
        {
            health.OnDie -= Die;
            health.OnDamaged -= ReceiveDamage;
        }
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

    protected virtual void Die()
    {
        animator.SetBool("Dead", true);
        //drop corpse from predefined list of corpses
        gameObject.SetActive(false);
        enabled = false;
    }

    protected virtual void ReceiveDamage(Vector3 direction)
    {
        animator.SetBoolTemporarily("Damaged", true);
        thisBody.linearVelocity += new Vector2(direction.x, 1) * defaultKickForce;
    }

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
