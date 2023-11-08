using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBuff : MonoBehaviour
{
    public int healthAmount = 1;
    public float followSpeed = 5.0f;

    Transform target;
    private Health health;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = target.GetComponent<Health>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        if (health.currentHealth < health.maxHealth)
        {
            // Calculate the amount to heal while respecting the max health
            int healAmount = Mathf.Min(healthAmount, health.maxHealth - health.currentHealth);
            health.currentHealth += healAmount;
            Destroy(gameObject);
        }
    }
}
