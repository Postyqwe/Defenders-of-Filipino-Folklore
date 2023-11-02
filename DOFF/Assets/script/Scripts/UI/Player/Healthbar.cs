using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthBar;

    private GameObject player;
    private Health health;

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            health = player.GetComponent<Health>();
            healthBar.maxValue = health.maxHealth;
        }

        healthBar.value = health.currentHealth;
    }
}
