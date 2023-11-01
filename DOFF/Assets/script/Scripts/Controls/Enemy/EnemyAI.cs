using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int damage = 1;
    public float atkSpeed = 0.5f;
    public float followRange = 5f;
    public float moveSpeed = 2f;
    public float attackRange = 1f;
    public bool isRangedEnemy = false;
    public GameObject bullet;

    public bool isDead = false;

    private Rigidbody rb;
    private Transform attackPoint;
    private Transform shootDirection;
    private Transform player;
    private Animator animator;
    private Health health;
    private float attackTimer = 0f;
    private bool isAttacking = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = player.GetComponent<Health>();
        attackTimer = atkSpeed;
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= followRange)
            {
                if (isRangedEnemy)
                {
                    RangedEnemyBehavior(distanceToPlayer);
                }
                else
                {
                    FollowPlayer(distanceToPlayer);
                    MeeleAttack();
                }
            }
            else
            {
                if (isRangedEnemy)
                {
                    StopShooting();
                }
                else
                {
                    StopFollowingPlayer();
                }
            }
        }
    }

    void FollowPlayer(float distanceToPlayer)
    {
        Vector3 playerPosition = player.position;
        Vector3 direction = playerPosition - transform.position;
        direction.Normalize();

        // Flip the enemy if the player is on the right
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        animator.SetBool("walk", true);
    }

    void StopFollowingPlayer()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("walk", false);
        animator.SetBool("attack", false);
    }

    void MeeleAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            if (!isAttacking && attackTimer >= atkSpeed)
            {
                health.GetHit(damage, transform.root.gameObject);
                isAttacking = true;
                animator.SetTrigger("attack");
                attackTimer = 0f;
            }
        }
        else
        {
            // Increase the attackTimer when no attack is performed
            attackTimer += Time.deltaTime;
            isAttacking = false;
        }
    }

    void RangedEnemyBehavior(float distanceToPlayer)
    {
        if (distanceToPlayer <= followRange)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 directionToPlayer = (player.position - attackPoint.position).normalized;
        GameObject newBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * moveSpeed;
    }

    void StopShooting()
    {

    }


    public void Die()
    {
        isDead = true;
        animator.SetBool("dead", true);
    }
}