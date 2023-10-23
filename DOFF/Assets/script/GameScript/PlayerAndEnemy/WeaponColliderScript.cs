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
            MeleeBoss meleeboss = collision.gameObject.GetComponent<MeleeBoss>(); // Try to get the Boss component from the collided object.

            if (meleeboss != null)
            {
                meleeboss.TakeDamage(2); 
            }
        }
        else if (collision.gameObject.CompareTag("BossRange")) // Check if it collides with an object with the "Boss" tag.
        {
            RangeBoss rangeboss = collision.gameObject.GetComponent<RangeBoss>(); // Try to get the Boss component from the collided object.

            if (rangeboss != null)
            {
                rangeboss.TakeDamage(2); 
            }
        }
        else if (collision.gameObject.CompareTag("Kapre")) // Check if it collides with an object with the "Boss" tag.
        {
            BossScript boss = collision.gameObject.GetComponent<BossScript>();
        
            if (boss != null)
            {
                boss.TakeDamage(2);
            }
        }
        else if (collision.gameObject.CompareTag("Tikbalang")) // Check if it collides with an object with the "Boss" tag.
        {
            BossScript boss = collision.gameObject.GetComponent<BossScript>();
        
            if (boss != null)
            {
                boss.TakeDamage(2);
            }
        }
    }
}