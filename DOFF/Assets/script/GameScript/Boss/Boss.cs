using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 25f; // Speed at which the boss charges.
    public float chargeCooldown = 5.0f; // Cooldown between charge attacks.
    public float chargeSpeed = 10.0f; // Speed at which the boss charges.
    public float chargeDuration = 2.0f; // Duration of the charge attack.
    private bool isCharging = false;
    private bool canCharge = true;
    public GameObject projectilePrefab; // Prefab for the boss's projectile.
    public Transform projectileSpawnPoint; // Where to spawn the projectile.
    // public float projectileForce = 60f; // Force applied to the projectile.
	public int chargeHitDamage = 20;
	public int fireHitDamage = 10;
	public int EnemyHealth = 6; //Enemy health
    public int currentHealth; //Variable that updates current health of the player
    public HealthBarScript healthBar; //Health bar to show how much health of the player have
	public float groundDist;
	public float fireRate = 1.0f;
    private float nextFireTime = 0.0f;

    private float timeSinceLastCharge = 0.0f;
	private float timeSinceLastAttack = 0f;
    public float timeBetweenAttacks = 3f;
    
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
        Charge,
        Projectile
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
        if(Physics.Raycast(castPos, -transform.up,out hit, Mathf.Infinity, terrainLayer)) //This is to check if the ground the player moving have a hill or not
        {
            if(hit.collider !=null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }
        
        Vector2 direction = player.position - transform.position;
        transform.LookAt(player.position); //Enemy identify and goes towards the target
        turnedLeft = false;
		if (player.position.x < transform.position.x) //To check if the target is on its left or right
		{
			animator.Play("left"); //If the target is towards the left this get activate
            turnedLeft = true;
		}
		else
		{
			animator.Play("right"); //If the target is towards the right this get activate 
		}
		transform.Rotate(new Vector3(0,-90,0),Space.Self);
		transform.Translate(new Vector3(moveSpeed* Time.deltaTime,0,0));
		transform.rotation = Quaternion.identity; //To calculate the rotation of the object

		timeSinceLastAttack += Time.deltaTime;
        timeSinceLastCharge += Time.deltaTime;

        if (timeSinceLastAttack >= timeBetweenAttacks)
        { 
            if (canCharge && timeSinceLastCharge >= chargeCooldown) // Check if the boss can charge and it's not on cooldown.
            {
                AttackType nextAttack = Random.Range(0, 2) == 0 ? AttackType.Charge : AttackType.Projectile; // Randomly select the next attack type (charge or projectile).

                if (nextAttack == AttackType.Charge)
                {
                    StartChargeAttack();
                }
                else
                {
                    StartProjectileAttack();
                }

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
        animator.SetTrigger("ChargeAttack");
        

        StartCoroutine(ChargeAttackRoutine());// Start a coroutine to execute the charge attack for a specific duration.
    }

    IEnumerator ChargeAttackRoutine()
    {
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = player.position;
        Vector3 directionToPlayer = (targetPosition - initialPosition).normalized;

        float timer = 0f;

        while (timer < chargeDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, timer / chargeDuration); // Move the boss in the direction of the player.

            timer += Time.deltaTime;
            yield return null;
        }

        isCharging = false;
        timeSinceLastCharge = 0.0f; // Reset the time since the last charge.
    }


    void FireProjectile()
    {
        Vector3 direction = player.position - transform.position; // Calculate the direction from the enemy to the player.
        
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity); // Create a bullet at the enemy's position.

        Rigidbody rb = bullet.GetComponent<Rigidbody>();// Get the Rigidbody component of the bullet.

        rb.velocity = direction.normalized * 100f; // Set the bullet's velocity to move towards the player and adjust the speed as needed.

    }

    
    public void StartProjectileAttack() // This method can be called from an animation event to trigger the projectile attack.
    {
		currentAttackType = AttackType.Projectile;
        animator.SetTrigger("RangeAttack");
		
        if (player !=null && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate; // Set the next fire time.
			FireProjectile();
        }
    }



	public int GetHitDamage() //Public function that return the enemy damage
    {
        if (currentAttackType == AttackType.Charge)
        {
            return chargeHitDamage;
        }
        else if (currentAttackType == AttackType.Projectile)
        {
            return fireHitDamage;
        }
        return 0;
    }
}