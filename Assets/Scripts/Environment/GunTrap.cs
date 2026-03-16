using System.Collections.Generic;
using UnityEngine;

public class GunTrap : MonoBehaviour
{
    [SerializeField]
    private List<Projectile> projectiles;
    
    [SerializeField]
    private float shootingTime;

    private float timer;

    private void Update()
    {
        if (timer <= 0)
        {
            timer = shootingTime;
            Shoot();
        }
        else
            timer -= Time.deltaTime;
    }

    private void Shoot()
    {
        foreach (var projectile in projectiles)
        {
            if (!projectile.gameObject.activeSelf)
            {
                projectile.Init(gameObject, transform.right, transform.position);
                break;
            }
        }
    }
}