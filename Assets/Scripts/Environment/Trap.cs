using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>()?.GetDamage(damage, transform.position - other.transform.position);
    }
}
