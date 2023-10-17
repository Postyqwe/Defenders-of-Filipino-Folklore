using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject boss; // The boss object.
    public GameObject[] enemies; // An array of enemy objects.
    public GameObject[] enemiesInRange; // An array of enemy objects with the "EnemyRange" tag.

    void Start()
    {
        // Initialize the array of enemies.
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Initialize the array of enemies with the "EnemyRange" tag.
        enemiesInRange = GameObject.FindGameObjectsWithTag("EnemyRange");

        // Ensure the boss object is initially disabled.
        boss.SetActive(false);
    }

    void Update()
    {
        if (boss == null)
        {
            // The boss object has been destroyed; no further action is needed.
            return;
        }

        // Check if all enemies, including those with "EnemyRange" tag, are defeated.
        if (AreAllEnemiesDefeated())
        {
            // Enable the boss object when all enemies are defeated.
            boss.SetActive(true);
        }
    }

    bool AreAllEnemiesDefeated()
    {
        if (enemies == null && enemiesInRange == null)
        {
            // Both enemy arrays are null, indicating they have been destroyed or not initialized.
            return true; // Treat this as all enemies defeated.
        }

        // Iterate through the enemies and check if any of them are active (not defeated).
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null && enemy.activeSelf)
                {
                    return false; // At least one enemy is still active.
                }
            }
        }

        // Iterate through the enemies with "EnemyRange" tag.
        if (enemiesInRange != null)
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