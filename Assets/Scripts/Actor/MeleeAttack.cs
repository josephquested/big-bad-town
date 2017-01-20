using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
	Animates animates;
	Moves moves;

	public bool attacking;
	public MeleeWeapon weapon;

	void Start () {
		animates = gameObject.GetComponent<Animates>();
		if (GetComponent<Moves>() != null) {
			moves = gameObject.GetComponent<Moves>();
		}
	}

	public void ReceiveInput () {
		ProcessAttack();
	}

	void ProcessAttack () {
		if (!attacking && weapon != null) {
			StartCoroutine(AttackCoroutine());
		}
	}

	IEnumerator AttackCoroutine () {
		float duration = weapon.attackSpeed;
		attacking = true;
		animates.Attacking(true);
		ProcessLumber(true);

		while (duration >= 0) {
			weapon.Attack(true);
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		ProcessLumber(false);
		attacking = false;
		animates.Attacking(false);
		weapon.Attack(false);
	}

	void ProcessLumber (bool shouldLumber) {
		if (moves != null) {
			moves.Lumber(shouldLumber, weapon.weight);
		}
	}
}
