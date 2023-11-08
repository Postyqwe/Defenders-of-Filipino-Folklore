using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    public UnityEvent OnAttackReference;
    [SerializeField] private InputActionReference attack;

    private Vector3 movement;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    Weapon weapon;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent <SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (weapon == null)
        {
            weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        UpdateDirection();

        UpdateAnimator();
    }

    private void OnMovement(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        movement = new Vector3(inputVector.x, 0, inputVector.y);
    }
    private void OnAttack(InputValue value)
    {
        weapon.Attack();
        OnAttackReference?.Invoke();
    }

    private void UpdateDirection()
    {
        if (movement.x < 0)
        {
            // Moving right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x > 0)
        {
            // Moving left
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void UpdateAnimator()
    {
        float movementMagnitude = movement.magnitude;
        bool isWalking = movementMagnitude > 0.1f;

        animator.SetBool("walking", isWalking);
    }
}
