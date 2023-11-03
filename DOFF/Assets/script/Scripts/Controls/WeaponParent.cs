using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    private bool swing = false;
    private int degree = 0;
    private float weaponY = -10.5f;
    private float weaponX = -8.8f;
    public float attackSpeed;
    private float attackTimer;
    private Vector3 pos;

    public GameObject player;
    private ButtonController button;

    private SpriteRenderer spriteRenderer;
    private Transform weaponCollision;

    public string enemyTag = "Enemy";

    private Transform nearestEnemy;

    private void Awake()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        weaponCollision = transform.GetChild(0);
    }

    private void Update()
    {
        FindNearestEnemy();

        attackTimer += Time.deltaTime;
        if (ShouldAttack())
        {
            ActivateWeapon();
            Attack();
            attackTimer = 0f;
        }
    }

    private bool ShouldAttack()
    {
        return (attackTimer >= attackSpeed && (button.isPressed || Input.GetKey(KeyCode.Space)));
    }

    private void ActivateWeapon()
    {
        spriteRenderer.enabled = true;
        weaponCollision.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (swing)
        {
            RotateTowardsNearestEnemy();
        }
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bossArray = GameObject.FindGameObjectsWithTag("Boss");

        GameObject[] allEnemies = new GameObject[enemyArray.Length + bossArray.Length];

        enemyArray.CopyTo(allEnemies, 0);
        bossArray.CopyTo(allEnemies, enemyArray.Length);

        nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in allEnemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
    }

    private void RotateTowardsNearestEnemy()
    {
        if (nearestEnemy != null)
        {
            Vector3 direction = nearestEnemy.position - transform.position;
            float targetRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            degree = Mathf.RoundToInt(targetRotation);
            transform.eulerAngles = Vector3.forward * degree;
        }
        else
        {
            ResetSwing();
        }
    }

    private void ResetSwing()
    {
        degree = 0;
        swing = false;
        spriteRenderer.enabled = false;
        weaponCollision.gameObject.SetActive(false);
    }

    private void Attack()
    {
        swing = true;
    }
}
