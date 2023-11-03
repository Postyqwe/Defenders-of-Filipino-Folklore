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
    private bool lvl1, lvl2, lvl3, lvl4, lvl5, lvl6, lvl7;
    private int bonusHp;
    private float bonusSpd;

    private void Start()
    {
        bonusHp += (lvl1 ? 1 : 0) + (lvl2 ? 1 : 0) + (lvl3 ? 1 : 0) + (lvl4 ? 1 : 0) + (lvl5 ? 1 : 0) + (lvl6 ? 1 : 0) + (lvl7 ? 1 : 0);
        bonusSpd = (lvl1 ? 0.3f : 0.0f) + (lvl2 ? 0.3f : 0.0f) + (lvl3 ? 0.3f : 0.0f) + (lvl4 ? 0.3f : 00.0f) + (lvl5 ? 0.3f : 0.0f) + (lvl6 ? 0.3f : 0.0f) + (lvl7 ? 0.3f : 0.0f);
        
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
        lvl1 = data.lvl1;
        lvl2 = data.lvl2;
        lvl3 = data.lvl3;
        lvl4 = data.lvl4;
        lvl5 = data.lvl5;
        lvl6 = data.lvl6;
        lvl7 = data.lvl7;
    }

    public void SaveData(GameData data)
    {

    }
}
