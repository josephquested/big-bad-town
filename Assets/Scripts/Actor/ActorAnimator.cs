using UnityEngine;
using System.Collections;

public class ActorAnimator : MonoBehaviour
{
	private Animator animator;
	private ActorMovement actorMovement;
	private ActorAttack actorAttack;

	void Start ()
	{
		animator = this.GetComponent<Animator>();
		actorMovement = this.GetComponent<ActorMovement>();
		actorAttack = this.GetComponent<ActorAttack>();
	}

	void FixedUpdate ()
	{
		animator.SetBool("attacking", actorAttack.Attacking);
		animator.SetInteger("direction", actorMovement.Direction);

		if (actorMovement.Moving)
		{
			animator.speed = 1;
		}
		else
		{
			animator.speed = 0;
		}
	}
}
