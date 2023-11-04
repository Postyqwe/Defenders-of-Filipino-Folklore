using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{  
    public GameObject healthUI;

    public Slider healthBar;
    public TMP_Text nameText;

    private GameObject boss;
    private Health health;
    private bool isBossDead = false;

    private void Update()
    {
        if (boss == null)
        {
            boss = GameObject.FindGameObjectWithTag("Boss");
            if (boss !=null && !isBossDead)
            {
                health = boss.GetComponent<Health>();
                healthBar.maxValue = health.maxHealth;
                nameText.text = health.name;
                healthUI.SetActive(true);
            }
        }
        else if(health.currentHealth <= 0)
        {
            boss = null;
            healthUI.SetActive(false);
            isBossDead = true;
        }
        if(health != null)
        {
            healthBar.value = health.currentHealth;
        }
    }
}
