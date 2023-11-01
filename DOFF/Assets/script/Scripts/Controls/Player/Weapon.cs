using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public int damage;

    private Animator animator;
    private bool isAttacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        StartCoroutine(AttackWithAnimation());
    }

    void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Health health;
                if (health = other.gameObject.GetComponent<Health>())
                {
                    Debug.Log("hit");
                    health.GetHit(damage, transform.root.gameObject);
                }
            }
        }
    }

    private IEnumerator AttackWithAnimation()
    {
        isAttacking = true;

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        isAttacking = false;

        gameObject.SetActive(false);
    }
}