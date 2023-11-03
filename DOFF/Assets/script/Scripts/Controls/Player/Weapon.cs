using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public int damage;

    [Header("Range")]
    public bool isRange = false;
    public GameObject bulletPrefab;
    public float bulletLifeTime = 2f;
    [Header("High FR = fast, Low FR = slow")]
    public float fireRate = 0.5f;

    private Animator animator;
    private bool isAttacking;
    private float nextFireTime;

    private void Awake()
    {
        animator = GetComponent <Animator>();
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
                if (health = other.gameObject.GetComponent<Health>())
                {
                    Debug.Log("Hit");
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
        if (enemies.Length == 0 || bosses.Length == 0)
        {
            return;
        }

        Transform nearestEnemy = GetNearestEnemy(enemies, bosses);
        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shoot(nearestEnemy, damage, bulletLifeTime);

            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private Transform GetNearestEnemy(GameObject[] enemies, GameObject[] bosses)
    {
        Transform nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        foreach (var boss in bosses)
        {
            float distance = Vector3.Distance(transform.position, boss.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = boss.transform;
            }
        }

        return nearestEnemy;
    }
}