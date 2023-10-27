using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float moveSpeed = 25f; //Speed at which the boss charges.
	public int EnemyHealth = 6; //Enemy health
    public int currentHealth; //Variable that updates current health of the player
    public HealthBarScript healthBar; //Health bar to show how much health of the player have
	public float groundDist; //Y position of this sprite
    public int hitdamage =10; //If it hit the target
    private float timeSinceLastAttack = 0f;
    private float attackTimer = 0f; //Timer for the attack duration
    public float timeBetweenAttacks = 2f;
    public float attackDuration = 2f; //New field for attack duration
    private float closeRangeAttackDistance = 50f; //If the target is in this range
    private float range; //for calculating distance of sprite to the player
    private float minDistance = 230.0f; //minimum distance that if the player is in range.
    private Transform player;
    public bool turnedLeft = false;
    public Behaviour script; //To disable a script
    private bool isDead = false; //For checking if it's still alive
    public LayerMask terrainLayer;
    private Animator animator;
    public AttackType currentAttackType;

    public enum AttackType //different attack types
    {
        None,
        CloseRange
    }

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentHealth = EnemyHealth; //Converting current health of the enemy
        healthBar.SetMaxHealth(EnemyHealth); //Max value of the max health for the health bar
    }

    void Update()
    {
		RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer)) //This is to check if the ground the player moving have a hill or not
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
        

        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            if (range < closeRangeAttackDistance) //Perform the close-range attack when the player is within the specified range.
            {
                StartCloseRangeAttack();
            }
        }

        
        if (currentAttackType == AttackType.CloseRange) //Update the attack timer and reset the attack type if the timer has expired.
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                attackTimer = 0f;
                currentAttackType = AttackType.None;
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

    void StartCloseRangeAttack()
    {
        if (range < closeRangeAttackDistance) //Check if the player is within close range (adjust the range as needed).
        { 
            currentAttackType = AttackType.CloseRange; //Set the attack type to CloseRange.

            if (player.position.x < transform.position.x) //Deal damage to the player. You can adjust the damage amount.
            {
                animator.SetTrigger("CloseRangeAttackLeft");
            }
            else
            {
                animator.SetTrigger("CloseRangeAttackRight");
            }
        }
    }
	public int GetHitDamage()
    {
        return hitdamage; //If it hit the target
    }
}