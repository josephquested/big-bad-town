using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
	public MeleeAttack meleeAttack;
	public RangedAttack rangedAttack;
	public Moves moves;

	public float triggerDelay;

	void Update () {
		if (moves != null) {
			UpdateDirection();
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			StartCoroutine(TriggerCoroutine());
		}
	}

	IEnumerator TriggerCoroutine () {
		yield return new WaitForSeconds(triggerDelay);
		FireTrigger();
	}

	void FireTrigger () {
		if (meleeAttack != null) {
			meleeAttack.ReceiveInput();
		}

		if (rangedAttack != null) {
			rangedAttack.ReceiveInput();
		}
	}

	void UpdateDirection () {
		if (moves.direction == 0) {
			transform.rotation = Quaternion.Euler(0, 0, 180);
		}
		if (moves.direction == 1) {
			transform.rotation = Quaternion.Euler(0, 0, 90);
		}
		if (moves.direction == 2) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if (moves.direction == 3) {
			transform.rotation = Quaternion.Euler(0, 0, 270);
		}
	}
}
