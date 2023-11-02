using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    public GameObject deathParticle;
    public bool isDead = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            UpdateAnimator();
            isDead = false;
        }
    }
    public void GetHit(int damage, GameObject sender)
    {
        currentHealth -= damage;
        OnHitWithReference?.Invoke(sender);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
        }
    }
    private void UpdateAnimator()
    {
        animator.SetBool("dead", isDead);
    }
    public void DestroyObject()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject); // Destroy the game object
    }
}
