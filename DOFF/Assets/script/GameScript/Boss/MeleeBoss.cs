using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBoss : MonoBehaviour
{
    public float moveSpeed = 25f; // Speed at which the boss charges.
    public float chargeCooldown = 5.0f; // Cooldown between charge attacks.
    public float chargeSpeed = 10.0f; // Speed at which the boss charges.
    public float chargeDuration = 2.0f; // Duration of the charge attack.
    private bool isCharging = false;
    private bool canCharge = true;
    // public float projectileForce = 60f; // Force applied to the projectile.
	public int chargeHitDamage = 20;
	public int EnemyHealth = 6; //Enemy health
    public int currentHealth; //Variable that updates current health of the player
    public HealthBarScript healthBar; //Health bar to show how much health of the player have
	public float groundDist;
    private float timeSinceLastCharge = 0.0f;
	private float timeSinceLastAttack = 0f;
    public float timeBetweenAttacks = 2f;
    private float range;
    private float minDistance = 230.0f;
    private Transform player;
    public bool turnedLeft = false;
    public Behaviour script; // To disable a script
    private bool isDead = false; // For checking if it's still alive
    public LayerMask terrainLayer;
    private Animator animator;
    public AttackType currentAttackType;

    public enum AttackType
    {
        None,
        Charge
    }

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentHealth = EnemyHealth;
        healthBar.SetMaxHealth(EnemyHealth);
    }

    void Update()
    {
		RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }
        range = Vector2.Distance(transform.position, player.position);
        if (range < minDistance && !isDead)
        {
            transform.LookAt(player.position);
            turnedLeft = false;
            if (player.position.x < transform.position.x)
            {
                animator.Play("left");
                turnedLeft = true;
            }
            else
            {
                animator.Play("right");
            }
        }
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        transform.rotation = Quaternion.identity;

        timeSinceLastAttack += Time.deltaTime;
        timeSinceLastCharge += Time.deltaTime;

        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            if (canCharge && timeSinceLastCharge >= chargeCooldown)
            {
                StartChargeAttack();
                timeSinceLastAttack = 0f;
            }
        }
        
    }
		
    

	public void TakeDamage(int amount) //Getting hit by the player weapon
    {
        currentHealth -= amount; //If it get hit enemy health gets lower
        transform.GetChild(0).gameObject.SetActive(true); //This activate the blood sprite
        if(currentHealth<1) //To check if enemy is still alive or not
        {
            isDead = true; //To indicate that the enemy is dead
            GetComponent<Rigidbody>().velocity = Vector3.zero; //To make sure that it doesnt slide/move still when it dies
            transform.GetChild(0).gameObject.SetActive(false); //To in-activate the blood
            animator.SetTrigger("death");
            script.enabled = false; //To disable this script
            GetComponent<Collider>().enabled = false; //To make sure that it doesnt collide with another entity even its dead
            PlayerController.coins++;
            Invoke("EnemyDeath",1.5f); //Enemy animation
        }
        healthBar.SetHealth(currentHealth); 
    }
	void EnemyDeath() //To remove the enemy sprite from the stage
    {
        Destroy(gameObject);
    }


    public void StartChargeAttack()
    {
        currentAttackType = AttackType.Charge;
        isCharging = true;

        if (turnedLeft)
        {
            animator.SetTrigger("ChargeAttackLeft");
        }
        else
        {
            animator.SetTrigger("ChargeAttackRight");
        }

        StartCoroutine(ChargeAttackRoutine()); // Start a coroutine to execute the charge attack for a specific duration.
    }

    IEnumerator ChargeAttackRoutine()
    {
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = player.position;
        Vector3 directionToPlayer = (targetPosition - initialPosition).normalized;

        float timer = 0f;
        float originalMoveSpeed = moveSpeed;

        while (timer < chargeDuration)
        {
            Vector3 newPosition = new Vector3(initialPosition.x + directionToPlayer.x * chargeSpeed * timer, initialPosition.y, initialPosition.z + directionToPlayer.z * chargeSpeed * timer);
            transform.position = newPosition;

            timer += Time.deltaTime;
            yield return null;
        }

        isCharging = false;
        timeSinceLastCharge = 0.0f; // Reset the time since the last charge.
        moveSpeed = originalMoveSpeed;
    }

	public int GetHitDamage()
    {
        if (currentAttackType == AttackType.Charge)
        {
            return chargeHitDamage;
        }
        return 0;
    }
}