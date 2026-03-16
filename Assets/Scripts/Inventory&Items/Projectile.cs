using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected GameObject ignore;
    private Health target;

    [SerializeField]
    protected float lifeTime = 20f;

    [SerializeField]
    protected int damage = 1;

    [SerializeField]
    protected float speed = 10f;

    [SerializeField]
    protected Rigidbody2D thisBody;

    protected float lifetimeTimer;

    void OnEnable()
    {
        thisBody.linearVelocity = transform.right * speed;
        lifetimeTimer = lifeTime;
    }

    private void Update()
    {
        if (lifetimeTimer > 0)
            lifetimeTimer -= Time.deltaTime;
        else
            gameObject.SetActive(false);
    }

    public void Init(GameObject newIgnore, Vector3 movingDirection, Vector3 newPosition)
    {
        ignore = newIgnore;
        SetVelocity(movingDirection);
        transform.position = newPosition;
        gameObject.SetActive(true);
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
        if (collision.gameObject == ignore) return;
        target = collision.gameObject.GetComponent<Health>();
        if (target != null)
            target.GetDamage(damage, transform.position - target.transform.position);
        gameObject.SetActive(false);
    }

    public float LifeTime => lifeTime;
}
