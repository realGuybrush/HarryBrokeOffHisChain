using System;
using UnityEngine;

[Serializable]
public class Health : MonoBehaviour
{
    [SerializeField]
    private AnimatorController animator;

    [SerializeField]
    private StatsController stats;
    
    [SerializeField]
    private float maxHealth = 10;

    [SerializeField]
    private float health = 10;

    public float GetDamage(float Damage) {
        float totalDamageReceived = Damage;
        if (totalDamageReceived > health)
            totalDamageReceived = health;
        health -= totalDamageReceived;
        if (health <= 0)
            animator.SetBool("Dead", true);
        else 
            animator.SetBoolTemporarily("Damaged", true);
        Debug.Log(totalDamageReceived);
        return totalDamageReceived;
    }

    public float MaxHP => maxHealth;

    public float HP => health;

}
