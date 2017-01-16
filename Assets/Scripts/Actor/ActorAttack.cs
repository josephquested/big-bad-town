using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAttack : MonoBehaviour
{
	private ActorMovement actorMovement;

	[SerializeField] private bool attacking;
	[SerializeField] private float attackSpeed;

	public Weapon weapon;

	void Start ()
	{
		actorMovement = this.GetComponent<ActorMovement>();
	}

	public void RecieveAttackInput (bool attackInput)
	{
		ProcessAttack(attackInput);
	}

	void ProcessAttack (bool attackInput)
	{
		if (!attacking && attackInput && weapon != null)
		{
			StartCoroutine(AttackCoroutine());
		}
	}

	IEnumerator AttackCoroutine ()
	{
		float duration = attackSpeed;
		attacking = true;
		actorMovement.CanMove = false;

		while (duration >= 0)
		{
			duration -= 0.1f;
			Attack();
			yield return new WaitForSeconds(0.01f);
		}

		attacking = false;
		actorMovement.CanMove = true;
		StopAttack();
	}

	void Attack ()
	{
		weapon.AttackInDirection(actorMovement.Direction);
	}

	public void StopAttack ()
	{
		weapon.StopAttack();
	}

	public bool Attacking
	{
		get { return attacking; }
	}
}
