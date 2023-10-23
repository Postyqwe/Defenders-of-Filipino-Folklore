using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{

	// public float speed = 2.5f;
	// public float attackRange = 100f;

	Transform player;
	Rigidbody rb;
	MeleeBoss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody>();
		boss = animator.GetComponent<MeleeBoss>();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//boss.LookAtPlayer();

		// Vector2 target = new Vector2(player.position.x, rb.position.y);
		// Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		// rb.MovePosition(newPos);

		if (boss.currentAttackType == MeleeBoss.AttackType.Charge)
        {
            
            boss.StartChargeAttack(); // Perform charge attack logic
        }
        
		
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetTrigger("ChargeAttack");
		
	}
}