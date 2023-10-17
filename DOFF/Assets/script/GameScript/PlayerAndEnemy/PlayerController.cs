using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed,  groundDist; //Player movement speed
    public bool turnedLeft = false;
    public int PlayerMaxHealth = 100; //Player max health
    public int currentHealth; //Variable that updates current health of the player
    public bool Dead = false;
    public LayerMask terrainLayer;
    private Rigidbody rb;
    public Animator animator;
    public FixedJoystick movementJoystick;
    public Behaviour script , scripta , scriptb;// , scriptc , scriptd; //To disable a script
    public HealthBarScript healthBar; //Health bar to show how much health of the player have
    public static int coins;
    public TextMeshProUGUI coinText;
    public GameObject mainText; //Temporary Game Over screen
    public GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentHealth = PlayerMaxHealth; 
        healthBar.SetMaxHealth(PlayerMaxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = " "+ coins;
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
    }
    void FixedUpdate()
    {
        /*if(movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * speed, movementJoystick.joystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if(movementJoystick.joystickVec.x > 0) //If the joystick moving towards the right side
        {
            animator.Play("right"); //Plays the animation
    
        }
        else if(movementJoystick.joystickVec.x < 0) //If the joystick moving towards the left side
        {
            animator.Play("left"); //Plays the animation
            turnedLeft = true;
            
        }*/
        float x = movementJoystick.Horizontal; //To get the x axis of the joystick
        float z = movementJoystick.Vertical; //To get the y axis of the joystick
        Vector3 direction = new Vector3(x,0,z).normalized; //This just normalize the value of x and y so its not a bunch of numbers
        transform.Translate(direction *speed, Space.World); //This make the sprite/player move
        turnedLeft = false;
        if(x > 0) //If the joystick moving towards the right side
        {
            animator.Play("right"); //Plays the animation
    
        }
        else if(x < 0) //If the joystick moving towards the left side
        {
            animator.Play("left"); //Plays the animation
            turnedLeft = true;
            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Boss")||collision.gameObject.CompareTag("EnemyRange"))//If the player and enemy collide this get trigger
        {
            if(collision.gameObject.GetComponent<EnemyScript>())
            {
                TakeDamage(collision.gameObject.GetComponent<EnemyScript>().GetHitDamage()); //Calculation for the player current health if it got hit by the enemy
            }
            if(collision.gameObject.GetComponent<Boss>())
            {
                TakeDamage(collision.gameObject.GetComponent<Boss>().GetHitDamage());
            }
            if(collision.gameObject.GetComponent<BossShooting>())
            {
                TakeDamage(collision.gameObject.GetComponent<BossShooting>().GetHitDamage());
            }
            if(collision.gameObject.GetComponent<EnemyShooting>())
            {
                TakeDamage(collision.gameObject.GetComponent<EnemyShooting>().GetHitDamage()); //Calculation for the player current health if it got hit by the enemy
            }
            if(collision.gameObject.GetComponent<EnemyShootingScript>())
            {
                TakeDamage(collision.gameObject.GetComponent<EnemyShootingScript>().GetHitDamage()); //Calculation for the player current health if it got hit by the enemy
            }
            
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Player took damage: " + amount);
        currentHealth -= amount;
        if(currentHealth < 1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero; //This just makes the player sprite not slide when it dies mid movement animation
            mainText.SetActive(true); //This show the Game over text on the screen
            Die();
            Dead = true;
        }
        healthBar.SetHealth(currentHealth); 
    }

    private void Die() //to disable the movement in the game when the player die
    {
        script.enabled = false;
        scripta.enabled = false;
        scriptb.enabled = false;
        //scriptc.enabled = false;
        //scriptd.enabled = false;
        //scripte.enabled = false;
        animator.SetTrigger("death");
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        coins = 0;
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("MENU");
    }
}

