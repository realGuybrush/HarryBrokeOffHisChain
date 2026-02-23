using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Health>()?.GetDamage(damage);
    }

    public float Damage { get => damage; set => damage = value; }
}
