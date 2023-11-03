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

    private void Update()
    {
        if (boss == null)
        {
            boss = GameObject.FindGameObjectWithTag("Boss");
            health = boss.GetComponent<Health>();
            healthBar.maxValue = health.maxHealth;
            nameText.text = health.name;
            healthUI.SetActive(true);
        }

        healthBar.value = health.currentHealth;
    }
}
