using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject boss; //The boss object.
    public GameObject[] enemies; //An array of enemy objects.
    public GameObject[] enemiesInRange; //An array of enemy objects with the "EnemyRange" tag.

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); //Initialize the array of enemies.
        enemiesInRange = GameObject.FindGameObjectsWithTag("EnemyRange"); //Initialize the array of enemies with the "EnemyRange" tag.
        boss.SetActive(false); //Ensure the boss object is initially disabled.
    }

    void Update()
    {
        if(boss == null)
        {
            return; //The boss object has been destroyed; no further action is needed.
        }
        if(AreAllEnemiesDefeated()) //Check if all enemies, including those with "EnemyRange" tag, are defeated.
        {
            boss.SetActive(true); //Enable the boss object when all enemies are defeated.
        }
    }

    bool AreAllEnemiesDefeated()
    {
        if (enemies == null && enemiesInRange == null)
        {
            // Both enemy arrays are null, indicating they have been destroyed or not initialized.
            return true; // Treat this as all enemies defeated.
        }
        if (enemies != null) //Iterate through the enemies and check if any of them are active (not defeated).
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null && enemy.activeSelf)
                {
                    return false; //At least one enemy is still active.
                }
            }
        }
        if (enemiesInRange != null) //Iterate through the enemies with "EnemyRange" tag.
        {
            foreach (GameObject enemy in enemiesInRange)
            {
                if (enemy != null && enemy.activeSelf)
                {
                    return false; // At least one enemy is still active.
                }
            }
        }
        return true; // All enemies are defeated.
    }
}   