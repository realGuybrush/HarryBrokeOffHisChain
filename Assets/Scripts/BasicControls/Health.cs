using System;
using UnityEngine;

[Serializable]
public class Health : MonoBehaviour
{
    [SerializeField]
    private AnimatorController animator;

    [SerializeField]
    private Rigidbody2D thisBody;
    
    [SerializeField]
    private int maxHealth = 10;

    [SerializeField]
    private int health = 10;

    public event Action<int> OnHeal = delegate { };
    public event Action<Vector3, int> OnDamaged = delegate { };
    public event Action OnDie = delegate { };

    public int GetDamage(int Damage, Vector3 direction) {
        int totalDamageReceived = Damage;
        if (totalDamageReceived > health)
            totalDamageReceived = health;
        health -= totalDamageReceived;
        OnDamaged?.Invoke(-direction, Damage);
        if (health <= 0)
        {
            OnDie?.Invoke();
        }
        return totalDamageReceived;
    }
    
    public void Heal(int amount) {
        health += amount;
        if (health > maxHealth)
            health = maxHealth;
        OnHeal?.Invoke(amount);
    }

    public float MaxHP => maxHealth;

    public float HP => health;

}
