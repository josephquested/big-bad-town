using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public bool attacking;
	public MeleeWeapon weapon;

	public void ReceiveInput () {
		ProcessAttack();
	}

	void ProcessAttack () {
		if (!attacking && weapon != null)
		{
			StartCoroutine(AttackCoroutine());
		}
	}

	IEnumerator AttackCoroutine ()
	{
		float duration = weapon.attackSpeed;
		attacking = true;

		while (duration >= 0)
		{
			weapon.Attack(true);
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}

		attacking = false;
		weapon.Attack(false);
	}
}
