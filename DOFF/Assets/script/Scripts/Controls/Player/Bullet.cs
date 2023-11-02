using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private int damage;
    private float bulletSpeed;
    private float bulletLifeTime;
    private float bulletTimer;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Move the bullet towards the target.
        Vector3 moveDirection = (target.position - transform.position).normalized;
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);

        // Check if the bullet should be destroyed after a certain time.
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(Transform newTarget, int newDamage, float newBulletLifeTime)
    {
        target = newTarget;
        damage = newDamage;
        bulletLifeTime = newBulletLifeTime;

        // Set the initial speed and timer values.
        bulletSpeed = 10f;
        bulletTimer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            Health health = target.GetComponent<Health>();
            if (health != null)
            {
                health.GetHit(damage, transform.root.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
