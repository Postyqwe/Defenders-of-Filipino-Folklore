using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour, IDataPersistence
{
    public Slider healthBar;
    public TMP_Text healthAmount;

    private GameObject player;
    private Health health;
    private PlayerMovement playerMovement;

    private int bonusHp;
    private float speedLevel;
    private float bonusSpd;

    private void Start()
    {
        bonusSpd = speedLevel * 0.1f;
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            health = player.GetComponent<Health>();
            playerMovement = player.GetComponent<PlayerMovement>();

            playerMovement.speed += bonusSpd;
            health.maxHealth += bonusHp;
            health.currentHealth += bonusHp;

            healthBar.maxValue = health.maxHealth;
        }
        healthAmount.text = health.currentHealth.ToString() + " / " + health.maxHealth.ToString();
        healthBar.value = health.currentHealth;
    }


    public void LoadData(GameData data)
    {
        bonusHp = data.healthLevel;
        speedLevel = data.speedLevel;
    }

    public void SaveData(GameData data)
    {

    }
}
