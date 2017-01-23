using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour {
	Rigidbody2D rb;
	Animator animator;

	public bool canMove;
	public int health;
	public float speed;
	public bool isMoving;
	public float minMovement;
	public float maxMovement;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		if (!isMoving && canMove){
			ProcessMovement();
		}
	}

	public void Activate () {
		canMove = true;
	}

	void ProcessMovement () {
		int direction = 1;
		if (Random.Range(0, 2) == 0) {
			direction = 3;
		}
		float duration = Random.Range(minMovement, maxMovement);
		StartCoroutine(MovementCoroutine(direction, duration));
	}

	IEnumerator MovementCoroutine (int direction, float duration) {
		isMoving = true;
		Vector2 movementVector = GetMovementVector(direction);
		rb.AddForce(movementVector * speed);
		while (duration >= 0) {
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}
		isMoving = false;
	}

	Vector2 GetMovementVector (int direction) {
		if (direction == 1) return new Vector2(1, 0);
		if (direction == 3) return new Vector2(-1, 0);
		return new Vector2(0, 0);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.GetComponent<ExplosionCollider>() != null) {
			health -= 1;
			print("got hit!");
		}
	}
}
