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

    [Header("Range")]
    public bool isRangedEnemy = false;
    public GameObject bullet;

    [Header("Debugging")]
    public bool isDead = false;

    private Rigidbody rb;
    
    private Transform shootDirection;
    private Transform player;
    private Animator animator;
    private Health health;
    private float attackTimer = 0f;
    private bool isAttacking = false;
    private float shootTimer = 0f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        attackTimer = atkSpeed;
    }

    private void FixedUpdate()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            health = player.GetComponent<Health>();
        }

        if (!isDead)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= followRange)
            {
                if (isRangedEnemy && distanceToPlayer <= attackRange)
                {
                    RangedEnemyBehavior(distanceToPlayer);
                }
                else if (isRangedEnemy && distanceToPlayer >= attackRange)
                {
                    FollowPlayer(distanceToPlayer);
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
        attackTimer += Time.fixedDeltaTime;
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
            isAttacking = false;
        }
    }

    void RangedEnemyBehavior(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            Shoot();
            StopFollowingPlayer();
        }
    }

    void Shoot()
    {
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer >= atkSpeed)
        {

            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = directionToPlayer * moveSpeed;
            shootTimer = 0f;
        }

        shootTimer += Time.fixedDeltaTime;
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