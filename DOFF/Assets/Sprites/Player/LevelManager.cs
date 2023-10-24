using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject nextLevel;
    public MeleeBoss boss; // Reference to your boss script

    void Update()
    {
        // Check if the boss is defeated during the game.
        if (boss.isDead)
        {
            // Show the next level UI.
            nextLevel.SetActive(true);
        }
    }

    public void NextLevel()
    {
        // Load the next scene based on the build index.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
