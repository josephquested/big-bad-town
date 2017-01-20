using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
	public MeleeAttack meleeAttack;
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
	}

	void UpdateDirection () {
		if (moves.direction == 0) transform.localPosition = new Vector2(0, 1);
		if (moves.direction == 1) transform.localPosition = new Vector2(1, 0);
		if (moves.direction == 2) transform.localPosition = new Vector2(0, -1);
		if (moves.direction == 3) transform.localPosition = new Vector2(-1, 0);
	}
}
