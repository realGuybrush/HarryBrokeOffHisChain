using System.Collections;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    public bool GetBool(string id)
    {
        return animator.GetBool(id);
    }
    
    public void SetBool(string id, bool value)
    {
        animator.SetBool(id, value);
    }

    public void SetBoolTemporarily(string id, bool value)
    {
        animator.SetBool(id, value);
        StartCoroutine(TurnOffAnimation(id, !value));
    }
    
    private IEnumerator TurnOffAnimation(string parameterName, bool oldValue)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool(parameterName, oldValue);
    }

    public void SetBoolTemporarily(string id, bool value, float time)
    {
        animator.SetBool(id, value);
        StartCoroutine(TurnOffAnimation(id, !value, time));
    }
    
    private IEnumerator TurnOffAnimation(string parameterName, bool oldValue, float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool(parameterName, oldValue);
    }
    
    public Vector2 DirectionVector()
    {
        Vector2 direction = Vector2.zero;
        if(animator.GetBool("Up"))
            direction = Vector2.up;
        if(animator.GetBool("Down"))
            direction = Vector2.down;
        if(animator.GetBool("Right"))
            direction = Vector2.right;
        if(animator.GetBool("Left"))
            direction = Vector2.left;
        return direction;
    }
}