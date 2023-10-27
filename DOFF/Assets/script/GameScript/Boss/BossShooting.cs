using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public float force =100f;
    private float timer;
    public int hitdamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position; //Calculate the direction vector from the projectile to the player
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; //Set the initial velocity of the projectile to move towards the player with the specified force
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg; //Calculate the rotation angle to point the projectile toward the player
        transform.rotation = Quaternion.Euler(0, 0, rot); //Set the rotation of the projectile to align with the calculated angle
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 2) //game object will get destroyed automatically if it didnt hit the player.
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            collide.gameObject.GetComponent<PlayerController>().TakeDamage(hitdamage);
            Destroy(gameObject); //Destroy the bullet here, if needed.
        }
    }

    public int GetHitDamage()
    {
        return hitdamage; //If it hit the target
    }
}
