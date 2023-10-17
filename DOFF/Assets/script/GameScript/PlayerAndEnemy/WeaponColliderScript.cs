using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Check if it collides with an object with the "Enemy" tag.
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>(); // Try to get the EnemyScript component from the collided object.

            if (enemy != null)
            {
                enemy.TakeDamage(3); // If the component exists, call the TakeDamage method.
            }
        }
        else if (collision.gameObject.CompareTag("EnemyRange")) // Check if it collides with an object with the "EnemyRange" tag.
        {
            
            EnemyShooting enemyShooting = collision.gameObject.GetComponent<EnemyShooting>(); // Try to get the EnemyShooting component from the collided object.

            if (enemyShooting != null)
            {
                
                enemyShooting.TakeDamage(3); 
            }
        }
        else if (collision.gameObject.CompareTag("Boss")) // Check if it collides with an object with the "Boss" tag.
        {
            Boss boss = collision.gameObject.GetComponent<Boss>(); // Try to get the Boss component from the collided object.

            if (boss != null)
            {
                boss.TakeDamage(2); 
            }
        }
    }
}
