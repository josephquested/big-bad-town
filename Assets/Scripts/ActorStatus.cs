using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStatus : Status {
	public PassiveAttack passiveAttack;
	public MeleeAttack meleeAttack;

	void Reset () {
		health = baseHealth;
	}

	public override void Die () {
		StartCoroutine(DeathCoroutine(1.5f));
	}

	IEnumerator DeathCoroutine (float duration) {
		for (float i = 0; i < duration; i++) {
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.black;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
		}
		gameObject.SetActive(false);
	}
}
