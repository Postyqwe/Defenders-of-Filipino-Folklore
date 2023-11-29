using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum WeaponStrength
{
    Tikbalang,
    Mananangal,
    Tyanak,
    Mangkukulam,
    WhiteLady,
    Kapre
}

public class Weapon : MonoBehaviour
{
    public List<WeaponStrength> strengths;
    public int baseDamage;

    [Header("Range")]
    public bool isRange = false;
    public GameObject bulletPrefab;
    public float bulletLifeTime = 2f;
    [Header("High FR = fast, Low FR = slow")]
    public float fireRate = 0.5f;

    private Animator animator;
    private bool isAttacking;
    private float nextFireTime;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        nextFireTime = Time.time;
    }

    public void Attack()
    {
        StartCoroutine(AttackWithAnimation());
        if (isRange)
        {
            if (CanShoot())
            {
                ShootBulletAtNearestEnemy();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
            {
                Health health;
                EnemyWeakness enemyWeakness;

                if (health = other.gameObject.GetComponent<Health>())
                {
                    // Get the EnemyWeakness component
                    enemyWeakness = other.gameObject.GetComponent<EnemyWeakness>();

                    // Initialize damage with the base damage
                    int damage = baseDamage;

                    // Check if the enemy has a weakness to the selected type
                    if (enemyWeakness != null && enemyWeakness.HasWeakness(strengths))
                    {
                        // Multiply the damage for the weakness
                        damage *= 2;
                    }

                    // Deal damage to the enemy
                    health.GetHit(damage, transform.root.gameObject);
                }
            }
        }
    }

    private IEnumerator AttackWithAnimation()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        isAttacking = false;
    }

    private bool CanShoot()
    {
        return Time.time >= nextFireTime;
    }

    private void ShootBulletAtNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        Transform nearestEnemy = GetNearestEnemy(enemies, bosses);
        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shoot(nearestEnemy, baseDamage, bulletLifeTime);

            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private Transform GetNearestEnemy(GameObject[] enemies, GameObject[] bosses)
    {
        Transform nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            // Check if the enemy is not dead
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null && !enemyHealth.isDead)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy.transform;
                }
            }
        }

        foreach (var boss in bosses)
        {
            // Check if the boss is not dead
            Health bossHealth = boss.GetComponent<Health>();
            if (bossHealth != null && !bossHealth.isDead)
            {
                float distance = Vector3.Distance(transform.position, boss.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = boss.transform;
                }
            }
        }

        return nearestEnemy;
    }
}
