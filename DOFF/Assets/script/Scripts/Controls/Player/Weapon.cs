using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
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

    private IEnumerator AttackWithAnimation()
    {
        isAttacking = true;

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        gameObject.SetActive(false);
    }
}