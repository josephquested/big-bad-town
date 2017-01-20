using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour {
	Vector2 previousPosition;

	public Moves moves;
	public bool isMoving;
	public bool randomMovement;
 	public float minMovement;
 	public float maxMovement;

	void Awake () {
		previousPosition = transform.position;
	}

	void Update () {
		previousPosition = transform.position;
		if (!isMoving){
			if (randomMovement) {
				ProcessRandomMovement();
			}
		}
	}

	public void Activate () {
		if (moves != null) {
			moves.canMove = true;
		}
	}

	void ProcessRandomMovement () {
		int direction = Random.Range(0, 4);
		float duration = Random.Range(minMovement, maxMovement);
		StartCoroutine(MovementCoroutine(direction, duration));
	}

	IEnumerator MovementCoroutine (int direction, float duration) {
		isMoving = true;
		while (duration >= 0) {
			duration -= 0.1f;
			moves.ProcessMovement(direction);
			yield return new WaitForSeconds(0.01f);
		}
		StopMovement();
	}

	public void StopMovement () {
		moves.ProcessMovement(-1);
		isMoving = false;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "GameScreen" && collider.gameObject != transform.parent) {
			transform.position = previousPosition;
		}
	}
}
