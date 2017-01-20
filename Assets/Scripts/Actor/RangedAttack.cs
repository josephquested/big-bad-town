using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {
	Animates animates;
	Moves moves;

	public RangedWeapon weapon;

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
		if (weapon != null) {
			if (!weapon.shooting) {
				StartCoroutine(AttackCoroutine());
			}
		}
	}

	IEnumerator AttackCoroutine () {
		animates.Attacking(true);
		ProcessLumber(true);
		weapon.Attack();

		while (weapon.shooting) {
			yield return new WaitForSeconds(0.01f);
		}

		ProcessLumber(false);
		animates.Attacking(false);
	}

	void ProcessLumber (bool shouldLumber) {
		if (moves != null) {
			moves.Lumber(shouldLumber, weapon.weight);
		}
	}
}
