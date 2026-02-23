using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected GameObject ignore;
    private Health target;

    [SerializeField]
    protected float lifeTime = 400;

    [SerializeField]
    protected float damage = 5;

    [SerializeField]
    protected float speed = 5f;

    [SerializeField]
    protected Rigidbody2D thisBody;

    void OnEnable()
    {
        thisBody.linearVelocity = transform.right * speed;
        StartCoroutine("WaitToDisable");
    }

    public void Init(GameObject newIgnore, Vector3 movingDirection, float newDamage, Vector3 newPosition)
    {
        ignore = newIgnore;
        SetVelocity(movingDirection);
        damage = newDamage;
        transform.position = newPosition;
    }

    protected virtual void SetVelocity(Vector3 movingDirection)
    {
        transform.right = movingDirection;
    }

    private IEnumerator WaitToDisable()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (damage > 0)
        {
            if (collision.gameObject == ignore) return;
            target = collision.gameObject.GetComponent<Health>();
            if (target != null)
                damage -= target.GetDamage(damage);
            if (damage <= 0)
                gameObject.SetActive(false);
        }
    }

    public float LifeTime => lifeTime;
}
