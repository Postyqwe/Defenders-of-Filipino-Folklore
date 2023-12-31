using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("Damage Amount")]
    public int damage = 1;//damage
    [Tooltip("Higher value = slower, Lower value = faster")]
    public float atkSpeed = 0.5f;//higher the slower fr
    [Tooltip("Has Gizmo")]
    public float followRange = 5f;//has gizmo
    [Tooltip("Higher value = faster, Lower value = slower")]
    public float moveSpeed = 2f;//higher speed faster
    [Tooltip("Has Gizmo")]
    public float attackRange = 1f;//has gizmo

    [Header("Range")]
    public bool isRangedEnemy = false;
    [Tooltip("Higher value = faster, Lower value = slower")]
    public float bulletSpeed = 0.2f;//higher is fast, lower is slow
    public GameObject bullet;

    [Header("BossType")]
    [Header("Kapre Stats")]
    public bool isKapre = false;
    public int stompDamage;
    public int logDamage;

    [Header("Debugging")]
    public bool isDead = false;

    private Rigidbody rb;

    private Collider col;
    private Transform shootDirection;
    private Transform player;
    private Animator animator;
    private Health health;
    private float attackTimer = 0f;
    private bool isAttacking = false;
    private float shootTimer = 0f;

    private bool hasPlayedAttackSound = false;
    AudioManager audioManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        audioManager = FindObjectOfType<AudioManager>();

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
    }

    void MeeleAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        attackTimer += Time.fixedDeltaTime;

        if (distanceToPlayer <= attackRange)
        {
            if (!isAttacking && attackTimer >= atkSpeed)
            {
                // Reset the flag for each melee attack
                hasPlayedAttackSound = false;

                int rand = Random.Range(0, 2);

                if (isKapre)
                {
                    if (rand == 0)
                    {
                        isAttacking = true;
                        animator.SetTrigger("stomp");
                        attackTimer = 0f;
                        logActtack();
                    }
                    else if (rand == 1)
                    {
                        isAttacking = true;
                        animator.SetTrigger("log");
                        attackTimer = 0f;
                        stompAttack();
                    }
                    else
                    {
                        Debug.Log("Randomized error");
                    }
                }
                else
                {
                    isAttacking = true;
                    animator.SetTrigger("attack");
                    attackTimer = 0f;
                    normalDamge();
                }
            }
        }
        else
        {
            // Increase the attackTimer when no attack is performed
            isAttacking = false;
        }
    }

    public void logActtack()
    {
        // Play the sound only if it hasn't been played yet
        if (!hasPlayedAttackSound)
        {
            audioManager.playmonsterAttack();
            hasPlayedAttackSound = true;
        }

        health.GetHit(logDamage, transform.root.gameObject);
    }

    public void stompAttack()
    {
        // Play the sound only if it hasn't been played yet
        if (!hasPlayedAttackSound)
        {
            audioManager.playmonsterAttack();
            hasPlayedAttackSound = true;
        }

        health.GetHit(logDamage, transform.root.gameObject);
    }

    public void normalDamge()
    {
        // Play the sound only if it hasn't been played yet
        if (!hasPlayedAttackSound)
        {
            audioManager.playmonsterAttack();
            hasPlayedAttackSound = true;
        }

        health.GetHit(damage, transform.root.gameObject);
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
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        shootTimer += Time.fixedDeltaTime;

        if (distanceToPlayer <= attackRange)
        {
            if (shootTimer >= atkSpeed)
            {
                if (!hasPlayedAttackSound)
                {
                    audioManager.playmonsterAttack();
                    hasPlayedAttackSound = true;
                }
                // Reset the flag for each shot
                hasPlayedAttackSound = false;

                animator.SetTrigger("attack");
                Vector3 directionToPlayer = (player.position - transform.position).normalized;
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().velocity = directionToPlayer * bulletSpeed;
                shootTimer = 0f;
            }
        }
        else
        {
            // Increase the shootTimer when no shot is performed
            shootTimer = atkSpeed;
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