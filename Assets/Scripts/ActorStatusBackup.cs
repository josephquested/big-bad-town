using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStatusBackup : Status {
	Vector2 spawnLocation;

	public Moves moves;
	public PassiveAttack passiveAttack;
	public MeleeAttack meleeAttack;

	void Awake () {
		spawnLocation = transform.position;
	}

	public void Activate () {
		ToggleMoves(true);
	}

	void Reset () {
		ToggleMoves(false);
		TogglePassiveAttack(true);
		ToggleMeleeAttack(true);
		collider.enabled = true;
		spriteRenderer.enabled = true;
		transform.position = spawnLocation;
		health = baseHealth;
	}

	public override void Die () {
		StartCoroutine(DeathCoroutine(1.5f));
	}

	IEnumerator DeathCoroutine (float duration) {
		ToggleMoves(false);
		TogglePassiveAttack(false);
		ToggleMeleeAttack(false);

		for (float i = 0; i < duration; i++) {
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.black;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
		}

		collider.enabled = false;
		spriteRenderer.enabled = false;
	}

	void ToggleMoves (bool toggle) {
		if (moves != null) {
			moves.canMove = toggle;
		}
	}

	void TogglePassiveAttack (bool toggle) {
		if (passiveAttack != null) {
			passiveAttack.enabled = toggle;
		}
	}

	void ToggleMeleeAttack (bool toggle) {
		if (meleeAttack != null) {
			meleeAttack.enabled = toggle;
		}
	}
}
